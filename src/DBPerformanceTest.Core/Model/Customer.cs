// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Customer.cs" company="Megadotnet">
//   Customer
// </copyright>
// <summary>
//   The customer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DBPerformanceTest.Core.Model
{
    /// <summary>
    /// The customer.
    /// </summary>
    public class Customer
    {
        #region Constants and Fields

        /// <summary>
        /// The _address.
        /// </summary>
        private string _address = string.Empty;

        /// <summary>
        /// The _city.
        /// </summary>
        private string _city = string.Empty;

        /// <summary>
        /// The _company name.
        /// </summary>
        private string _companyName = string.Empty;

        /// <summary>
        /// The _contact name.
        /// </summary>
        private string _contactName = string.Empty;

        /// <summary>
        /// The _contact title.
        /// </summary>
        private string _contactTitle = string.Empty;

        /// <summary>
        /// The _country.
        /// </summary>
        private string _country = string.Empty;

        /// <summary>
        /// The _customer id.
        /// </summary>
        private string _customerID = string.Empty;

        /// <summary>
        /// The _fax.
        /// </summary>
        private string _fax = string.Empty;

        /// <summary>
        /// The _phone.
        /// </summary>
        private string _phone = string.Empty;

        /// <summary>
        /// The _postal code.
        /// </summary>
        private string _postalCode = string.Empty;

        /// <summary>
        /// The _region.
        /// </summary>
        private string _region = string.Empty;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets Address.
        /// </summary>
        public string Address
        {
            get
            {
                return this._address;
            }

            set
            {
                this._address = value;
            }
        }

        /// <summary>
        /// Gets or sets City.
        /// </summary>
        public string City
        {
            get
            {
                return this._city;
            }

            set
            {
                this._city = value;
            }
        }

        /// <summary>
        /// Gets or sets CompanyName.
        /// </summary>
        public string CompanyName
        {
            get
            {
                return this._companyName;
            }

            set
            {
                this._companyName = value;
            }
        }

        /// <summary>
        /// Gets or sets ContactName.
        /// </summary>
        public string ContactName
        {
            get
            {
                return this._contactName;
            }

            set
            {
                this._contactName = value;
            }
        }

        /// <summary>
        /// Gets or sets ContactTitle.
        /// </summary>
        public string ContactTitle
        {
            get
            {
                return this._contactTitle;
            }

            set
            {
                this._contactTitle = value;
            }
        }

        /// <summary>
        /// Gets or sets Country.
        /// </summary>
        public string Country
        {
            get
            {
                return this._country;
            }

            set
            {
                this._country = value;
            }
        }

        /// <summary>
        /// Gets or sets CustomerID.
        /// </summary>
        public string CustomerID
        {
            get
            {
                return this._customerID;
            }

            set
            {
                this._customerID = value;
            }
        }

        /// <summary>
        /// Gets or sets Fax.
        /// </summary>
        public string Fax
        {
            get
            {
                return this._fax;
            }

            set
            {
                this._fax = value;
            }
        }

        /// <summary>
        /// Gets or sets Phone.
        /// </summary>
        public string Phone
        {
            get
            {
                return this._phone;
            }

            set
            {
                this._phone = value;
            }
        }

        /// <summary>
        /// Gets or sets PostalCode.
        /// </summary>
        public string PostalCode
        {
            get
            {
                return this._postalCode;
            }

            set
            {
                this._postalCode = value;
            }
        }

        /// <summary>
        /// Gets or sets Region.
        /// </summary>
        public string Region
        {
            get
            {
                return this._region;
            }

            set
            {
                this._region = value;
            }
        }

        #endregion
    }
}