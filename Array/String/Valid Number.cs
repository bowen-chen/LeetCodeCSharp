/*
65	Valid Number
easy, state machine
Validate if a given string is numeric.

Some examples:
"0" => true
" 0.1 " => true
"abc" => false
"1 a" => false
"2e10" => true
*/

using System;
using System.Collections.Generic;

namespace Demo
{
    public partial class Solution
    {
        public void IsNumber_Test()
        {
            string a = "1.0";
            Console.WriteLine("{0} => {1}", a, IsNumber(a));

            a = " +1.0e-8  ";
            Console.WriteLine("{0} => {1}", a, IsNumber(a));

            a = "0.1";
            Console.WriteLine("{0} => {1}", a, IsNumber(a));

            a = "1";
            Console.WriteLine("{0} => {1}", a, IsNumber(a));

            a = "a";
            Console.WriteLine("{0} => {1}", a, IsNumber(a));
        }

        public bool IsNumber(string s)
        {
            State state = State.Begin;
            Dictionary<State, Dictionary<Action, State>> sm = CreateStateMachine();

            foreach (char c in s)
            {
                Action action = GetAction(c);
                if (action == Action.Invalid)
                {
                    return false;
                }
                if (sm[state].ContainsKey(action))
                {
                    state = sm[state][action];
                }
                else
                {
                    return false;
                }
            }
            return state == State.Int || state == State.IntDot
                   || state == State.Decimal || state == State.EInt
                   || state == State.End;
        }

        private static Dictionary<State, Dictionary<Action, State>> CreateStateMachine()
        {
            Dictionary<State, Dictionary<Action, State>> stateMachine =
                new Dictionary<State, Dictionary<Action, State>>
                {
                    {
                        State.Begin, new Dictionary<Action, State>
                        {
                            {Action.Space, State.Begin},
                            {Action.Sign, State.Sign},
                            {Action.Number, State.Int},
                            {Action.Dot, State.DotOnly}
                        }
                    },
                    {
                        State.Sign, new Dictionary<Action, State>
                        {
                            {Action.Dot, State.DotOnly},
                            {Action.Number, State.Int}
                        }
                    },
                    {
                        State.Int, new Dictionary<Action, State>
                        {
                            {Action.E, State.E},
                            {Action.Dot, State.IntDot},
                            {Action.Number, State.Int},
                            {Action.Space, State.End}
                        }
                    },
                    {
                        State.DotOnly, new Dictionary<Action, State>
                        {
                            {Action.Number, State.Decimal}
                        }
                    },
                    {
                        State.IntDot, new Dictionary<Action, State>
                        {
                            {Action.Number, State.Decimal},
                            {Action.Space, State.End},
                            {Action.E, State.E}
                        }
                    },
                    {
                        State.Decimal, new Dictionary<Action, State>
                        {
                            {Action.E, State.E},
                            {Action.Space, State.End},
                            {Action.Number, State.Decimal}
                        }
                    },
                    {
                        State.E, new Dictionary<Action, State>
                        {
                            {Action.Sign, State.ESign},
                            {Action.Number, State.EInt}
                        }
                    },
                    {
                        State.ESign, new Dictionary<Action, State>
                        {
                            {Action.Number, State.EInt}
                        }
                    },
                    {
                        State.EInt, new Dictionary<Action, State>
                        {
                            {Action.Space, State.End},
                            {Action.Number, State.EInt}
                        }
                    },
                    {
                        State.End, new Dictionary<Action, State>
                        {
                            {Action.Space, State.End}
                        }
                    }
                };

            return stateMachine;
        }

        private Action GetAction(char c)
        {
            if (c == ' ')
            {
                return Action.Space;
            }
            if (c == '+' || c == '-')
            {
                return Action.Sign;
            }
            if (c >= '0' && c <= '9')
            {
                return Action.Number;
            }
            if (c == '.')
            {
                return Action.Dot;
            }
            if (c == 'e' || c == 'E')
            {
                return Action.E;
            }
            return Action.Invalid;
        }

        private enum Action
        {
            Space,
            Sign,
            Number,
            Dot,
            E,
            Invalid
        }

        private enum State
        {
            Begin,
            Sign,
            Int,
            IntDot,
            DotOnly,
            Decimal,
            E,
            ESign,
            EInt,
            End
        }
    }
}
