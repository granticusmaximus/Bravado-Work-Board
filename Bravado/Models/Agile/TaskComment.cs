using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bravado.Models.Agile
{
    public class TaskComment
    {
        #region TASK COMMENT
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CommentId { get; set; }
        public Models.Agile.Task MainTaskId { get; set; }
        public string CommentTitle { get; set; }
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }
        public DateTime CommentDueDate { get; set; }
        public Priority PriorityProp { get; set; }
        #endregion
    }
    public enum Priority
    {
        Select,
        Low,
        Medium,
        High
    }
}