using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dz5_2client_recieve
{
    public sealed class ListEntity
    {
        private static  ListEntity sample;
        //если экземпляр уже создан, то просто возвращем его, иначе создаем
        public static ListEntity Sample
        {
            get
            {
                if (sample == null)
                {
                    sample = new ListEntity();
                }
                return sample;
            }
        }
        private static readonly List<Entity> list = new List<Entity>();
        //добавляем в список новые данные
        public void AddEntity(Entity entity)
        {
            list.Add(entity);
        }
    }
}