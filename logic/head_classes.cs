using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dogenova
{

    class head_classes
    {

    }

    class battler
    {
        public int hp, maxHp, pa, pd, ma, md, sp, ev, cr, id;
        public bool front, ally, dead, defending;

        public battler(int _hp, int _pa, int _pd, int _ma, int _md, int _sp, int _ev, int _cr, int _id, bool _front, bool _ally)
        {
            maxHp = _hp;
            hp = _hp;
            pa = _pa;
            pd = _pd;
            ma = _ma;
            md = _md;
            sp = _sp;
            ev = _ev;
            cr = _cr;
            front = _front;
            ally = _ally;
            dead = false;
            defending = false;
            id = _id;
        }

        public battler Clone()
        {
            battler res = new battler(this.hp, this.pa, this.pd, this.ma, this.md, this.sp, this.ev, this.cr, this.id, this.front, this.ally);

            res.maxHp = this.maxHp;

            return res;
        }

        public override string ToString()
        {
            return (this.ally) ? "Ally "+(this.id+1) : "Enemy "+(this.id-3);
        }
    }

    class phases
    {
        public List<int>[] pre_combat;
        public List<int>[] combat;
        public List<int>[] post_combat;

        public phases()
        {
            pre_combat = new List<int>[8];
            combat = new List<int>[8];
            post_combat = new List<int>[8];

            for (int i = 0; i < 8; i++)
            {
                pre_combat[i] = new List<int>();
                combat[i] = new List<int>();
                post_combat[i] = new List<int>();
            }
        }

        public phases Clone()
        {
            phases r = new phases();

            for (int i = 0; i < 8; i++)
            {
                r.pre_combat[i] = new List<int>();
                r.combat[i] = new List<int>();
                r.post_combat[i] = new List<int>();

                foreach (int j in this.pre_combat[i])
                    r.pre_combat[i].Add(j);

                foreach (int j in this.combat[i])
                    r.combat[i].Add(j);

                foreach (int j in this.post_combat[i])
                    r.post_combat[i].Add(j);
            }

            return r;
        }

        public void Dispose()
        {
            for (int i = 0; i < 8; i++)
            {
                this.pre_combat[i] = null;
                this.combat[i] = null;
                this.post_combat[i] = null;
            }
        }
    }

    class node
    {
        public int depth, value, first, last, parent, alpha, beta;

        public bool valuated, visited;

        public battler[] battlers;

        public phases orders;

        public node(int _depth, int _parent, battler[] _battlers, phases _main)
        {
            depth = _depth;
            parent = _parent;

            battlers = _battlers;

            orders = _main;

            value = (_depth % 2 == 0) ? int.MinValue : int.MaxValue; 
            
            first = -1; 
            last = -1;

            alpha = int.MinValue;
            beta = int.MaxValue;

            visited = false;

            valuated = false;
        }

        public battler[] CloneBattlers()
        {
            battler[] result = new battler[8];

            for (int i = 0; i < 8; i++)
            {
                result[i] = this.battlers[i].Clone();
            }

            return result;
        }

        public void Clear()
        {
            Array.Clear(this.battlers, 0, this.battlers.Length);
            this.orders.Dispose();
        }
    }
}
