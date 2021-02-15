using System;
using System.Collections.Generic;


namespace AppartmentChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] req = { "gym", "school", "store" };

            BlockItem[] blocks = {
                new BlockItem { gym = false, school = true, store = false },
                new BlockItem { gym = true, school = false, store = false },
                new BlockItem { gym = true, school = true, store = false },
                new BlockItem { gym = false, school = true, store = false },
                new BlockItem { gym = false, school = true, store = true },
            };

            //Your Code here...
            //foreach (BlockItem bi in blocks){
            //    Console.Out.WriteLine(bi.gym.ToString() + " " + bi.school.ToString() + " "+ bi.store.ToString());
            //}
            Console.Out.WriteLine(bestAppartment(blocks, req));
            Console.Out.WriteLine(blocks[bestAppartment(blocks, req)].gym.ToString() + " " + blocks[bestAppartment(blocks, req)].school.ToString() + " " + blocks[bestAppartment(blocks, req)].store.ToString());
        }

   
        public static int bestAppartment(BlockItem[] blocks, string[] req)
        {
            int bestPosition = 0;
            int total = int.MaxValue;
            for(int i = 0; i<blocks.Length; i++)
            {
                if (blocks[i].gym && blocks[i].school && blocks[i].store) return i;
                else
                {
                    int parcialTotal = 0;
                    foreach(string r in req)
                    {
                        int distancia = blocks.Length;
                        for(int j = 0; j < blocks.Length; j++)
                        {
                            if (blocks[j].getValue(r) && Distance(i,j) <= distancia){
                                distancia = Distance(i, j);
                            }

                        }
                        parcialTotal += distancia;
                    }
                    if(parcialTotal <= total)
                    {
                        bestPosition = i;
                        total = parcialTotal;
                    }
                }
            }
            return bestPosition;
        }
        public static int Distance(int a, int b)
        {
            return Math.Abs(a - b);
        }

    }



    public struct BlockItem
    {
        public bool gym; 
        public bool school;
        public bool store;

        public bool getValue(string property)
        {
            switch (property)
            {
                case "gym":
                    return this.gym;
                case "school":
                    return this.school;
                case "store":
                    return this.store;
                default:
                    return false;
            }
        }


    }
    
}

