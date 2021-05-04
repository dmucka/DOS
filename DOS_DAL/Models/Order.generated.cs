//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
//
//     Produced by Entity Framework Visual Editor v3.0.4.7
//     Source:                    https://github.com/msawczyn/EFDesigner
//     Visual Studio Marketplace: https://marketplace.visualstudio.com/items?itemName=michaelsawczyn.EFDesigner
//     Documentation:             https://msawczyn.github.io/EFDesigner/
//     License (MIT):             https://github.com/msawczyn/EFDesigner/blob/master/LICENSE
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DOS_DAL.Models
{
   /// <summary>
   /// Model for Order.
   /// </summary>
   [System.ComponentModel.Description("Model for Order.")]
   public partial class Order: DOS_DAL.Interfaces.IBaseModel, DOS_DAL.Interfaces.ITrackEdit, DOS_DAL.Interfaces.ITrackCreate, DOS_DAL.Interfaces.ISoftDelete
   {
      partial void Init();

      /// <summary>
      /// Default constructor
      /// </summary>
      public Order()
      {
         ManufacturingSteps = new System.Collections.ObjectModel.ObservableCollection<global::DOS_DAL.Models.ManufacturingStep>();

         Init();
      }

      /// <summary>
      /// Public constructor with required data
      /// </summary>
      /// <param name="status">Status of order.</param>
      /// <param name="serialnumber">Serial Number of order.</param>
      /// <param name="customer">Customer of order.</param>
      /// <param name="created">When was Order Created.</param>
      /// <param name="edited">When was Order last Edited.</param>
      /// <param name="isdeleted">Soft deleted flag.</param>
      /// <param name="product">Product FK</param>
      public Order(string status, string serialnumber, string customer, DateTime created, DateTime edited, bool isdeleted, global::DOS_DAL.Models.Product product)
      {
         if (string.IsNullOrEmpty(status)) throw new ArgumentNullException(nameof(status));
         this.Status = status;

         if (string.IsNullOrEmpty(serialnumber)) throw new ArgumentNullException(nameof(serialnumber));
         this.SerialNumber = serialnumber;

         if (string.IsNullOrEmpty(customer)) throw new ArgumentNullException(nameof(customer));
         this.Customer = customer;

         this.Created = created;

         this.Edited = edited;

         this.IsDeleted = isdeleted;

         if (product == null) throw new ArgumentNullException(nameof(product));
         this.Product = product;

         this.ManufacturingSteps = new System.Collections.ObjectModel.ObservableCollection<global::DOS_DAL.Models.ManufacturingStep>();
         Init();
      }

      /// <summary>
      /// Static create function (for use in LINQ queries, etc.)
      /// </summary>
      /// <param name="status">Status of order.</param>
      /// <param name="serialnumber">Serial Number of order.</param>
      /// <param name="customer">Customer of order.</param>
      /// <param name="created">When was Order Created.</param>
      /// <param name="edited">When was Order last Edited.</param>
      /// <param name="isdeleted">Soft deleted flag.</param>
      /// <param name="product">Product FK</param>
      public static Order Create(string status, string serialnumber, string customer, DateTime created, DateTime edited, bool isdeleted, global::DOS_DAL.Models.Product product)
      {
         return new Order(status, serialnumber, customer, created, edited, isdeleted, product);
      }

      /*************************************************************************
       * Properties
       *************************************************************************/

      /// <summary>
      /// Identity, Indexed, Required
      /// Unique identifier
      /// </summary>
      [Key]
      [Required]
      [System.ComponentModel.Description("Unique identifier")]
      public int Id { get; set; }

      /// <summary>
      /// Backing field for Status
      /// </summary>
      protected string _status;
      /// <summary>
      /// When provided in a partial class, allows value of Status to be changed before setting.
      /// </summary>
      partial void SetStatus(string oldValue, ref string newValue);
      /// <summary>
      /// When provided in a partial class, allows value of Status to be changed before returning.
      /// </summary>
      partial void GetStatus(ref string result);

      /// <summary>
      /// Required, Max length = 255
      /// Status of order.
      /// </summary>
      [Required]
      [MaxLength(255)]
      [StringLength(255)]
      [System.ComponentModel.Description("Status of order.")]
      public string Status
      {
         get
         {
            string value = _status;
            GetStatus(ref value);
            return (_status = value);
         }
         set
         {
            string oldValue = _status;
            SetStatus(oldValue, ref value);
            if (oldValue != value)
            {
               _status = value;
               OnPropertyChanged();
            }
         }
      }

      /// <summary>
      /// Backing field for SerialNumber
      /// </summary>
      internal string _serialNumber;
      /// <summary>
      /// When provided in a partial class, allows value of SerialNumber to be changed before setting.
      /// </summary>
      partial void SetSerialNumber(string oldValue, ref string newValue);
      /// <summary>
      /// When provided in a partial class, allows value of SerialNumber to be changed before returning.
      /// </summary>
      partial void GetSerialNumber(ref string result);

      /// <summary>
      /// Indexed, Required, Max length = 255
      /// Serial Number of order.
      /// </summary>
      [Required]
      [MaxLength(255)]
      [StringLength(255)]
      [System.ComponentModel.Description("Serial Number of order.")]
      public string SerialNumber
      {
         get
         {
            string value = _serialNumber;
            GetSerialNumber(ref value);
            return (_serialNumber = value);
         }
         set
         {
            string oldValue = _serialNumber;
            SetSerialNumber(oldValue, ref value);
            if (oldValue != value)
            {
               _serialNumber = value;
               OnPropertyChanged();
            }
         }
      }

      /// <summary>
      /// Backing field for Customer
      /// </summary>
      protected string _customer;
      /// <summary>
      /// When provided in a partial class, allows value of Customer to be changed before setting.
      /// </summary>
      partial void SetCustomer(string oldValue, ref string newValue);
      /// <summary>
      /// When provided in a partial class, allows value of Customer to be changed before returning.
      /// </summary>
      partial void GetCustomer(ref string result);

      /// <summary>
      /// Required, Max length = 255
      /// Customer of order.
      /// </summary>
      [Required]
      [MaxLength(255)]
      [StringLength(255)]
      [System.ComponentModel.Description("Customer of order.")]
      public string Customer
      {
         get
         {
            string value = _customer;
            GetCustomer(ref value);
            return (_customer = value);
         }
         set
         {
            string oldValue = _customer;
            SetCustomer(oldValue, ref value);
            if (oldValue != value)
            {
               _customer = value;
               OnPropertyChanged();
            }
         }
      }

      /// <summary>
      /// Backing field for Notes
      /// </summary>
      protected string _notes;
      /// <summary>
      /// When provided in a partial class, allows value of Notes to be changed before setting.
      /// </summary>
      partial void SetNotes(string oldValue, ref string newValue);
      /// <summary>
      /// When provided in a partial class, allows value of Notes to be changed before returning.
      /// </summary>
      partial void GetNotes(ref string result);

      /// <summary>
      /// Max length = 1023
      /// Notes for order.
      /// </summary>
      [MaxLength(1023)]
      [StringLength(1023)]
      [System.ComponentModel.Description("Notes for order.")]
      public string Notes
      {
         get
         {
            string value = _notes;
            GetNotes(ref value);
            return (_notes = value);
         }
         set
         {
            string oldValue = _notes;
            SetNotes(oldValue, ref value);
            if (oldValue != value)
            {
               _notes = value;
               OnPropertyChanged();
            }
         }
      }

      /// <summary>
      /// Backing field for Created
      /// </summary>
      protected DateTime _created;
      /// <summary>
      /// When provided in a partial class, allows value of Created to be changed before setting.
      /// </summary>
      partial void SetCreated(DateTime oldValue, ref DateTime newValue);
      /// <summary>
      /// When provided in a partial class, allows value of Created to be changed before returning.
      /// </summary>
      partial void GetCreated(ref DateTime result);

      /// <summary>
      /// Required
      /// When was Order Created.
      /// </summary>
      [Required]
      [System.ComponentModel.Description("When was Order Created.")]
      public DateTime Created
      {
         get
         {
            DateTime value = _created;
            GetCreated(ref value);
            return (_created = value);
         }
         set
         {
            DateTime oldValue = _created;
            SetCreated(oldValue, ref value);
            if (oldValue != value)
            {
               _created = value;
               OnPropertyChanged();
            }
         }
      }

      /// <summary>
      /// Backing field for Edited
      /// </summary>
      protected DateTime _edited;
      /// <summary>
      /// When provided in a partial class, allows value of Edited to be changed before setting.
      /// </summary>
      partial void SetEdited(DateTime oldValue, ref DateTime newValue);
      /// <summary>
      /// When provided in a partial class, allows value of Edited to be changed before returning.
      /// </summary>
      partial void GetEdited(ref DateTime result);

      /// <summary>
      /// Required
      /// When was Order last Edited.
      /// </summary>
      [Required]
      [System.ComponentModel.Description("When was Order last Edited.")]
      public DateTime Edited
      {
         get
         {
            DateTime value = _edited;
            GetEdited(ref value);
            return (_edited = value);
         }
         set
         {
            DateTime oldValue = _edited;
            SetEdited(oldValue, ref value);
            if (oldValue != value)
            {
               _edited = value;
               OnPropertyChanged();
            }
         }
      }

      /// <summary>
      /// Backing field for IsDeleted
      /// </summary>
      protected bool _isDeleted;
      /// <summary>
      /// When provided in a partial class, allows value of IsDeleted to be changed before setting.
      /// </summary>
      partial void SetIsDeleted(bool oldValue, ref bool newValue);
      /// <summary>
      /// When provided in a partial class, allows value of IsDeleted to be changed before returning.
      /// </summary>
      partial void GetIsDeleted(ref bool result);

      /// <summary>
      /// Required
      /// Soft deleted flag.
      /// </summary>
      [Required]
      [System.ComponentModel.Description("Soft deleted flag.")]
      public bool IsDeleted
      {
         get
         {
            bool value = _isDeleted;
            GetIsDeleted(ref value);
            return (_isDeleted = value);
         }
         set
         {
            bool oldValue = _isDeleted;
            SetIsDeleted(oldValue, ref value);
            if (oldValue != value)
            {
               _isDeleted = value;
               OnPropertyChanged();
            }
         }
      }

      /*************************************************************************
       * Navigation properties
       *************************************************************************/

      /// <summary>
      /// User FK
      /// </summary>
      [Description("User FK")]
      public virtual global::DOS_DAL.Models.User CreatedBy { get; set; }

      /// <summary>
      /// User FK
      /// </summary>
      [Description("User FK")]
      public virtual global::DOS_DAL.Models.User EditedBy { get; set; }

      /// <summary>
      /// Required&lt;br/&gt;
      /// Product FK
      /// </summary>
      [Description("Product FK")]
      public virtual global::DOS_DAL.Models.Product Product { get; set; }

      /// <summary>
      /// Collection of ManufacturingSteps
      /// </summary>
      [Description("Collection of ManufacturingSteps")]
      public virtual ICollection<global::DOS_DAL.Models.ManufacturingStep> ManufacturingSteps { get; private set; }

   }
}

