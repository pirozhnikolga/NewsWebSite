using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainObjects
{
    public class News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NewsID { get; set; }
        [Display(Name = "Заголовок")]
        public string Header { get; set; }
        [Display(Name = "Содержание")]
        public string Body { get; set; }
        [Display(Name = "Дата создания")]
        public DateTime CreateData { get; set; }
        [Display(Name = "Рейтинг")]
        public bool Hot { get; set; }
        [Display(Name = "Тип")]
        public TypeEnum Type { get; set; }

        public virtual List<Comment> Comments { get; set; }
    }
}
