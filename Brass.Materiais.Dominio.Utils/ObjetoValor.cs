﻿using Flunt.Notifications;
using Flunt.Validations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brass.Materiais.Dominio.Utils
{
    public abstract class ObjetoValor : Notifiable
    {
        //[BsonRepresentation(BsonType.ObjectId)]
        //public virtual string Id { get; private set; }
      

    }
}
