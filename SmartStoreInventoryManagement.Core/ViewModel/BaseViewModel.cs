using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace SmartStoreInventoryManagement.Core.ViewModel
{
    public abstract class BaseViewModel<T>
    {
        public BaseViewModel()
        {
            ErrorList = new List<string>();
        }

        public string Id { get; set; }
        public virtual Boolean HasError
        {
            get
            {
                if (this.ErrorList.Any())
                    return true;

                return false;
            }
        }

        public virtual List<string> ErrorList { get; set; }

        [JsonIgnore]
        public Guid Created_Id { get; set; }
        [JsonIgnore]
        public int TotalCount { get; set; }

        public T Payload { get; set; }
        public string CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }

    public abstract class BaseViewModel : BaseViewModel<string>, IValidatableObject
    {

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Created_Id == Guid.Empty)
            {
                yield return new ValidationResult("User editting record couldn't be determined");
            }
        }
    }
}
