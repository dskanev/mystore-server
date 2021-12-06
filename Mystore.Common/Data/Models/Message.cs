using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Data.Models
{
    public class Message
    {
        public string _serializedData;

        public Message(object data)
            => this.Data = data;

        private Message()
        { 
        }

        public long Id { get; private set; }
        public Type Type { get; private set; }
        public bool IsPublished { get; private set; }

        public void MarkAsPublished() => this.IsPublished = true;

        [NotMapped]
        public object Data
        {
            get => JsonConvert.DeserializeObject(this._serializedData, this.Type,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            set
            {
                this.Type = value.GetType();

                this._serializedData = JsonConvert.SerializeObject(value,
                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            }
        }
    }
}
