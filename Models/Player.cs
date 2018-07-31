using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MostSnake.Models
{
    public class Player
    {
        public int PlayerId { get; set; }
        public virtual Snake Snake { get; set; }
    }
}