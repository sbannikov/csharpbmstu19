using System;
using System.Runtime.Serialization;

namespace EntityClassLibrary
{
    [Serializable]
    [DataContract]
    public class Entity
    {
        // Уникальный идентификатор источника выбросов
        [DataMember(Name = "source_uuid")]
        public string source_uuid { get; set; }

        // Порядковый номер источника выбросов
        [DataMember(Name = "pniv")]
        public int pniv { get; set; }

        // Уникальный идентификатор датчика
        [DataMember(Name = "sensor_uuid")]
        public string sensor_uuid { get; set; }

        // Состояние датчика
        [DataMember(Name = "state")]
        public string state { get; set; }
        
        // Уникальный идентификатор показания
        [DataMember(Name = "parameter_uuid")]
        public string parameter_uuid { get; set; }

        // Тип показания
        [DataMember(Name = "code")]
        public string code { get; set; }

        // Единица измерения показания
        [DataMember(Name = "unit")]
        public string unit { get; set; }

        // Тип данных показания
        [DataMember(Name = "type")]
        public string type { get; set; }

        // Уникальный идентификатор значения показания
        [DataMember(Name = "value_uuid")]
        public string value_uuid { get; set; }

        // Отметка времени начала усреднения значения показания
        [DataMember(Name = "timestamp_start")]
        public int timestamp_start { get; set; }

        //Отметка времени окончания усреднения значения показания
        [DataMember(Name = "timestamp_end")]
        public int timestamp_end { get; set; }

        // Значение показания
        [DataMember(Name = "value")]
        public string value { get; set; }

        public Entity()
        {

        }
    }
}
