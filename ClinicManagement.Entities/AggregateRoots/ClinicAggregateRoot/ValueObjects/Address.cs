using ClinicManagement.Entities.Common;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagement.Entities.AggregateRoots.ClinicAggregateRoot.ValueObjects
{
    public class Address : BaseValueObject
    {
        #region Ctors
        public Address(string country, string state, string city, string section, string region, decimal longitude, decimal latitude)
        {
            Country = country;
            State = state;
            City = city;
            Section = section;
            Region = region;
            Longitude = longitude;
            Latitude = latitude;
        }

        public Address(string country, string state, string city, string section,
            string region, decimal longitude, decimal latitude, List<string>? interCities = null, List<string>? interRegions = null)
        {
            Country = country;
            State = state;
            City = city;
            Section = section;
            Region = region;
            Longitude = longitude;
            Latitude = latitude;
            InterCities = interCities;
            InterRegions = interRegions;
        }
        private Address() { }


        #endregion

        #region Properties
        /// <summary>
        /// کشور
        /// </summary>
        public string Country { get; private set; }
        /// <summary>
        /// استان
        /// </summary>
        public string State { get; private set; }
        /// <summary>
        /// شهر
        /// </summary>
        public string City { get; private set; }
        /// <summary>
        /// بحش
        /// </summary>
        public string Section { get; private set; }
        /// <summary>
        /// روستا یا دهستان
        /// </summary>
        public string Region { get; private set; }
        /// <summary>
        /// طول جغرافیای
        /// </summary>
        public decimal Longitude { get; private set; }
        /// <summary>
        /// عرض جغرافیای
        /// </summary>
        public decimal Latitude { get; private set; }


        /// <summary>
        /// بین شهری 
        /// </summary>
        public string InterCitiesAsJson { get; private set; }
        [NotMapped]
        public List<string>? InterCities
        {
            get
            {
                return JsonConvert.DeserializeObject<List<string>>
                    (InterCitiesAsJson);
            }
            private set
            {
                InterCitiesAsJson = JsonConvert.SerializeObject
                    (value, Formatting.None);
            }
        }

        /// <summary>
        /// بین روستایی
        /// </summary>
        public string InterRegionsAsJson { get; private set; }
        [NotMapped]
        public List<string>? InterRegions
        {
            get
            {
                return JsonConvert.DeserializeObject<List<string>>
                    (InterRegionsAsJson);
            }
            private set
            {
                InterRegionsAsJson = JsonConvert.SerializeObject
                    (value, Formatting.None);
            }
        }
        #endregion
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Country;
            yield return State;
            yield return City;
            yield return Section;
            yield return Region;
            yield return Longitude;
            yield return Latitude;
        }
    }
}
