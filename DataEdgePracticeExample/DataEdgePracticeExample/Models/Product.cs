using System;
using System.Collections.Generic;
<<<<<<< HEAD
using System.ComponentModel.DataAnnotations;
=======
>>>>>>> 21700f2598e03859bce24c8af740325630087921
using System.Linq;
using System.Web;

namespace DataEdgePracticeExample.Models
{
    public class Product
    {
<<<<<<< HEAD
        [Required]
        public virtual int Id { get; set; }

        [Required]
        public virtual string Name { get; set; }

        [Required]
=======
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
>>>>>>> 21700f2598e03859bce24c8af740325630087921
        public virtual decimal Price { get; set; }
    }
}