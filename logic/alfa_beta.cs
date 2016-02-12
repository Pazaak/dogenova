using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dogenova
{
    class alfa_beta
    {
        public static phases AIOrders(battler[] battlers, int[] tiers, bool con1, int maxDepth)
        {
            int next = 0, prev = -1;

            List<node> tree = new List<node>();

            node root = new node(0, -1, battlers, new phases());

            tree.Add(root);

            while (!root.valuated)
            {
                // DEBUG
                node temp = tree[next];
                //

                if (!tree[next].visited) // Traversing the tree downwards, creating nodes and evaluating
                {
                    if ((tree[next].depth % 2 == 0) && (tree[next].depth != 0)) // Pair levels hold full orders
                    {
                        tree[next].battlers = tree[next].CloneBattlers();
                        combat_methods.SimulateCombat(tree[next].orders, tree[next].battlers); // Simulate battle
                    }

                    if (tree[next].depth != maxDepth) // Last level must not be populated
                    {
                        populate(tree, tiers, con1, next);
                        tree[next].visited = true;
                        if (tree[next].first == tree.Count)
                        {
                            tree[next].valuated = true;
                            prev = next;
                            next = tree[next].parent;
                        }
                        else
                        {
                            tree[tree[next].first].alpha = tree[next].alpha;
                            tree[tree[next].first].beta = tree[next].beta;
                            prev = next;
                            next = tree[next].first; // Visit first child
                        }
                    }
                    else // Last level of the tree
                    {
                        tree[next].value = valuate(tree[next].battlers, con1);
                        tree[next].visited = true;
                        tree[next].valuated = true;
                        tree[next].Clear();
                        prev = next;
                        next = tree[next].parent;
                    }
                    
                }
                else //Going up
                {
                    // DEBUG
                    node n1 = tree[next];
                    node n2 = tree[prev];
                    // DEBUG

                    if (tree[next].depth % 2 == 0) //MAX node
                    {
                        if (tree[next].alpha < tree[prev].value) // Update Alpha
                            tree[next].alpha = tree[prev].value;
                        if (tree[next].value < tree[prev].value) // Update Value
                        {
                            if (tree[next].depth == 0)
                                tree[next].orders = tree[prev].orders; // Updating orders on root
                            tree[next].value = tree[prev].value;
                        }
                    }
                    else if (tree[next].depth % 2 == 1) //MIN node
                    {
                        if (tree[next].beta > tree[prev].value) // Update Beta
                            tree[next].beta = tree[prev].value;
                        if (tree[next].value > tree[prev].value) // Update Value
                            tree[next].value = tree[prev].value;
                    }


                    if (tree[next].alpha >= tree[next].beta)
                    {
                        if ( tree[next].depth % 2 == 0 )
                            tree[next].value = (tree[next].value < tree[next].alpha) ? tree[next].value : tree[next].alpha;
                        else
                            tree[next].value = (tree[next].value > tree[next].beta) ? tree[next].value : tree[next].beta;

                        tree[next].valuated = true;

                        breakBranch(tree, next, prev + 1);

                        prev = next;
                        next = tree[next].parent;
                    }
                    else
                    {
                        int it = prev;

                        while (it < tree[next].last && (tree[it] == null || tree[it].valuated)) it++;

                        if (it == tree[next].last)
                        {
                            if (tree[next].depth % 2 == 0)
                                tree[next].value = (tree[next].value < tree[next].alpha) ? tree[next].value : tree[next].alpha;
                            else
                                tree[next].value = (tree[next].value > tree[next].beta) ? tree[next].value : tree[next].beta;

                            tree[next].valuated = true;
                            prev = next;
                            next = tree[next].parent;
                        }
                        else
                        {
                            tree[it].alpha = tree[next].alpha;
                            tree[it].beta = tree[next].beta;
                            prev = next;
                            next = it;
                        }
                    }
                }
            }

            tree.Clear();

            phases finalActions = root.orders;

            return finalActions; // node.initializated
        }

        private static void populate(List<node> _tree, int[] tiers, bool con1, int id)
        {
            // Assign the index of the first child
            _tree[id].first = _tree.Count();

            // Calculate back targets and front targets
            int nDepth = _tree[id].depth;
            int first = (nDepth % 2 == 0) ^ con1 ? 0 : 4;
            battler[] _battlers = _tree[id].battlers;
            List<int> frontTargets = new List<int>();
            List<int> backTargets = new List<int>();

            for (int k = first; k < first+4; k++)
            {
                if (!_battlers[k].dead)
                {
                    if (_battlers[k].front)
                        frontTargets.Add(k);
                    else
                        backTargets.Add(k);
                }
            }

            // Populate the node
            populateIter(_tree, tiers, con1, id, _tree[id].orders, _battlers, frontTargets, backTargets, 0);

            // Assign the index of the last child
            _tree[id].last = _tree.Count();
        }

        private static void populateIter(List<node> _tree, int[] tiers, bool con1, int id, phases act, battler[] btls, List<int> frontTargets, List<int> backTargets, int fill)
        {
            int nDepth = _tree[id].depth;
            if (fill == 4) // Phases are complete, add them to the tree
            {
                node temp = new node(nDepth + 1, id, btls, act);
                temp.alpha = _tree[id].alpha;
                temp.beta = _tree[id].beta;
                _tree.Add(temp);
                return;
            }
            // Get the battler whose actions must be determined
            // if pair depth -> MAX node
            //  if con1 -> [0-3] battlers
            //  if !con1 -> [4-7] battlers
            // if impair depth -> MIN node
            //  if con1 -> [4-7] battlers
            //  if !con1 -> [0-3] battlers
            // MAX ^ con1? 4+fill : fill
            int act_btl = (nDepth % 2 == 0) ^ con1 ? 4+fill : fill;
            
            // Check if the battler is dead, ignore the battler
            if (btls[act_btl].dead)
            {
                populateIter(_tree, tiers, con1, id, act, btls, frontTargets, backTargets, fill + 1);
                return;
            }

            // Defend
            phases neoPhases = act.Clone();
            neoPhases.pre_combat[tiers[act_btl]].Add(Constants.F_DEFEND);
            neoPhases.pre_combat[tiers[act_btl]].Add(act_btl);
            neoPhases.post_combat[tiers[act_btl]].Add(Constants.F_DEFEND);
            neoPhases.post_combat[tiers[act_btl]].Add(act_btl);
            populateIter(_tree, tiers, con1, id, neoPhases, btls, frontTargets, backTargets, fill + 1);


            // Attack back targets (if possible)
            if (frontTargets.Count == 0 || !btls[act_btl].front)
            {
                foreach (int a in backTargets)
                {
                    neoPhases = act.Clone();
                    neoPhases.combat[tiers[act_btl]].Add(Constants.F_ATTACK);
                    neoPhases.combat[tiers[act_btl]].Add(act_btl);
                    neoPhases.combat[tiers[act_btl]].Add(a);
                    populateIter(_tree, tiers, con1, id, neoPhases, btls, frontTargets, backTargets, fill + 1);
                }
            }

            // Attack front targets
            foreach (int a in frontTargets)
            {
                neoPhases = act.Clone();
                neoPhases.combat[tiers[act_btl]].Add(Constants.F_ATTACK);
                neoPhases.combat[tiers[act_btl]].Add(act_btl);
                neoPhases.combat[tiers[act_btl]].Add(a);
                populateIter(_tree, tiers, con1, id, neoPhases, btls, frontTargets, backTargets, fill + 1);
            }


        }

        private static int valuate(battler[] field, bool con1)
        {
            int aggro = 3; // Pending to be externalized: 1 min agrro
            int deadAllies = 0, deadEnemies = 0, frontDeadAllies = 0, frontDeadEnemies = 0 ;
            int frontAllies = 0, frontEnemies = 0, differentialAllies = 0, differentialEnemies = 0;

            for (int i = con1 ? 0 : 4; i < (con1 ? 4 : 8); i++)
            {
                deadAllies += field[i].dead ? 1 : 0;
                frontDeadAllies += (field[i].dead && field[i].front) ? 1 : 0;
                frontAllies += field[i].front ? 1 : 0;
                if ( !field[i].dead )
                    differentialAllies += (int)( (field[i].maxHp - field[i].hp) * 100 / field[i].maxHp);
            }

            for (int i = con1 ? 4 : 0; i < (con1 ? 8 : 4); i++)
            {
                deadEnemies += field[i].dead ? 1 : 0;
                frontDeadEnemies += (field[i].dead && field[i].front) ? 1 : 0;
                frontEnemies += field[i].front ? 1 : 0;
                if (!field[i].dead)
                    differentialEnemies += (int)( (field[i].maxHp - field[i].hp) * 100 / field[i].maxHp);
            }

            if (deadEnemies == 4 && deadAllies == 4) // Tie
                return 0;

            if (deadEnemies == 4) // AI lose
                return int.MaxValue;

            if (deadAllies == 4) // AI win
                return int.MinValue;

            int value = deadEnemies * 500 - deadAllies * aggro * 500;
            value += differentialEnemies - differentialAllies;
            value -= (frontAllies == frontDeadAllies) ? (4-deadAllies) * (frontEnemies - frontDeadEnemies) * 100 : 0;
            value += (frontEnemies == frontDeadEnemies) ? (4-deadEnemies) * (frontAllies-frontDeadAllies) * 100 : 0;

            return value;
        }

        private static void breakBranch(List<node> tree, int act, int pre)
        {
                for (int i = pre; i < tree[act].last; i++)
                {
                    if (tree[i] != null)
                    {
                        breakBranch(tree, i, tree[i].first);
                        tree[i] = null;
                    }
                }
        }
    }
}
