using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dogenova
{
    class alfa_beta
    {
        public static phases AIOrders(battler[] battlers, int maxDepth)
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

                if (!tree[next].visited) // Going down
                {
                    if ((tree[next].depth % 2 == 0) && (tree[next].depth != 0)) // Pair levels hold full orders
                    {
                        tree[next].battlers = tree[next].CloneBattlers();
                        combat_methods.SimulateCombat(tree[next].orders, tree[next].battlers); // Simulate battle
                    }

                    if (tree[next].depth != maxDepth) // Last level must not be populated
                    {
                        populate(tree, next);
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
                        tree[next].value = valuate(tree[next].battlers);
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

                        //tree[next].Clear();
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

        private static void populate(List<node> _tree, int id)
        {
            // DEBUG
            node n1 = _tree[id];
            node n2 = _tree[0];
            // DEBUG

            int[] speeds = new int[8];
            int[] tiers = new int[8];

            int selector = 0;

            battler[] _battlers = _tree[id].battlers;
            bool AI = (_tree[id].depth % 2 == 0);

            List<phases>[] swap = new List<phases>[2];
            swap[0] = new List<phases>();
            swap[1] = new List<phases>();

            for (int i = 0; i < 8; i++)
            {
                tiers[i] = i;
                speeds[i] = _battlers[i].sp;
            }

            tiers = combat_methods.combatSpeed(speeds);

            swap[0].Add(_tree[id].orders);

            for (int i = AI? 4 : 0; i < (AI? 8 : 4); i++)
            {
                if (!_battlers[i].dead)
                {
                    selector = (swap[0].Count > swap[1].Count) ? 0 : 1;

                    for (int j = 0; j < swap[selector].Count; j++)
                    {

                        // Defense
                        phases temp = swap[selector][j].Clone();

                        temp.pre_combat[tiers[i]].Add(Constants.F_DEFEND);
                        temp.pre_combat[tiers[i]].Add(i);
                        temp.post_combat[tiers[i]].Add(Constants.F_DEFEND);
                        temp.post_combat[tiers[i]].Add(i);

                        swap[1 - selector].Add(temp);

                        // Attack

                        List<int> frontTargets = new List<int>();
                        List<int> backTargets = new List<int>();

                        for (int k = AI ? 0 : 4; k < (AI ? 4 : 8); k++)
                        {
                            if (!_battlers[k].dead)
                            {
                                if (_battlers[k].front)
                                    frontTargets.Add(k);
                                else
                                    backTargets.Add(k);
                            }
                        }

                        if (frontTargets.Count == 0 || !_battlers[i].front)
                        {
                            foreach (int a in backTargets)
                            {
                                phases temp1 = swap[selector][j].Clone();
                                temp1.combat[tiers[i]].Add(Constants.F_ATTACK);
                                temp1.combat[tiers[i]].Add(i);
                                temp1.combat[tiers[i]].Add(a);
                                swap[1 - selector].Add(temp1);
                            }
                        }

                        foreach (int a in frontTargets)
                        {
                            phases temp1 = swap[selector][j].Clone();
                            temp1.combat[tiers[i]].Add(Constants.F_ATTACK);
                            temp1.combat[tiers[i]].Add(i);
                            temp1.combat[tiers[i]].Add(a);
                            swap[1 - selector].Add(temp1);
                        }

                    }
                    swap[selector].Clear();
                }
            }

            _tree[id].first = _tree.Count;

            int nDepth = _tree[id].depth + 1;

            selector = (swap[0].Count > swap[1].Count) ? 0 : 1;

            foreach (phases p in swap[selector])
            {
                node temp = new node(nDepth, id, _battlers, p);
                temp.alpha = _tree[id].alpha;
                temp.beta = _tree[id].beta;
                _tree.Add(temp);
            }

            _tree[id].last = _tree.Count;
        }

        private static int valuate(battler[] field)
        {
            int aggro = 3; // Pending to be externalized: 1 min agrro
            int deadAllies = 0, deadEnemies = 0, frontDeadAllies = 0, frontDeadEnemies = 0 ;
            int frontAllies = 0, frontEnemies = 0, differentialAllies = 0, differentialEnemies = 0;

            for (int i = 0; i < 4; i++)
            {
                deadAllies += field[i].dead ? 1 : 0;
                frontDeadAllies += (field[i].dead && field[i].front) ? 1 : 0;
                frontAllies += field[i].front ? 1 : 0;
                if ( !field[i].dead )
                    differentialAllies += (int)( (field[i].maxHp - field[i].hp) * 100 / field[i].maxHp);
            }

            for (int i = 4; i < 8; i++)
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
                return int.MinValue;

            if (deadAllies == 4) // AI win
                return int.MaxValue;

            int value = deadAllies * aggro * 500 - deadEnemies * 500;
            value += differentialAllies * aggro - differentialEnemies;
            value += (frontAllies == frontDeadAllies) ? (4-deadAllies) * (frontEnemies - frontDeadEnemies) * aggro * 100 : 0;
            value -= (frontEnemies == frontDeadEnemies) ? (4-deadEnemies) * (frontAllies-frontDeadAllies) * 100 : 0;

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
