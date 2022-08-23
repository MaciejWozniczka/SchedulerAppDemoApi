using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduler.Api.Data
{
    public class BaseModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    }
}
