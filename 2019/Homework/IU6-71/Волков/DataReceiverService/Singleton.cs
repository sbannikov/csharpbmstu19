using EntityClassLibrary;
using System;
using System.Collections.Generic;

namespace DataReceiverService
{
    public sealed class Singleton
    {
        private static volatile Singleton instance;

        private static readonly List<Entity> list = new List<Entity>();

        private static readonly object syncRoot = new Object();

        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Singleton();                       
                    }
                }

                return instance;
            }
        }

        public void AddEntity (Entity entity)
        {
            list.Add(entity);
        }
    }

}