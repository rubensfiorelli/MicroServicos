using System.ComponentModel.DataAnnotations;

namespace GeekShow.Product.Api.Entities
{
    public abstract class BaseEntity
    {

        [Key]
        public Guid Id { get; protected set; }
        protected BaseEntity(DateTime? updateAt)
        {
            Id = Guid.NewGuid();
            UpdateAt = updateAt;
        }

        private DateTime? _createAt;
        public DateTime? CreateAt
        {
            get { return _createAt; }
            set { _createAt = value == null ? DateTime.UtcNow : value; }
        }

        public DateTime? UpdateAt { get; set; }
    }
}
