using Domain.Common;

namespace Domain.Entities
{
    public class Customer : AuditableBaseEntity
    {

        public string? Name { get; set; }
        public string? LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }

        private int _edad;
        public int Edad
        {
            get 
            {
                if (this._edad <= 0)
                {
                    this._edad = new DateTime(DateTime.Now.Subtract(this.BirthDate).Ticks).Year - 1; 
                }
                return this._edad;
            }
        }
    }
}
