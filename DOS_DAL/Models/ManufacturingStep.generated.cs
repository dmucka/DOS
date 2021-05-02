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
   /// Model for ManufacturingStep,
   /// </summary>
   [System.ComponentModel.Description("Model for ManufacturingStep,")]
   public partial class ManufacturingStep: DOS_DAL.Interfaces.IBaseModel, DOS_DAL.Interfaces.ITrackEdit
   {
      partial void Init();

      /// <summary>
      /// Default constructor. Protected due to required properties, but present because EF needs it.
      /// </summary>
      protected ManufacturingStep()
      {
         Wavelength = 0;
         Intensity = 0;
         Temperature = 0;
         Humidity = 0;

         Init();
      }

      /// <summary>
      /// Replaces default constructor, since it's protected. Caller assumes responsibility for setting all required values before saving.
      /// </summary>
      public static ManufacturingStep CreateManufacturingStepUnsafe()
      {
         return new ManufacturingStep();
      }

      /// <summary>
      /// Public constructor with required data
      /// </summary>
      /// <param name="wavelength">Wavelength value.</param>
      /// <param name="intensity">Intensity value.</param>
      /// <param name="temperature">Temperature value.</param>
      /// <param name="humidity">Humidity value.</param>
      /// <param name="edited">When was ManufacturingStep last Edited.</param>
      /// <param name="process">Process FK</param>
      /// <param name="order">Order FK</param>
      public ManufacturingStep(DateTime edited, global::DOS_DAL.Models.Process process, global::DOS_DAL.Models.Order order, decimal wavelength = 0m, decimal intensity = 0m, decimal temperature = 0m, decimal humidity = 0m)
      {
         this.Wavelength = wavelength;

         this.Intensity = intensity;

         this.Temperature = temperature;

         this.Humidity = humidity;

         this.Edited = edited;

         if (process == null) throw new ArgumentNullException(nameof(process));
         this.Process = process;

         if (order == null) throw new ArgumentNullException(nameof(order));
         this.Order = order;
         order.ManufacturingSteps.Add(this);

         Init();
      }

      /// <summary>
      /// Static create function (for use in LINQ queries, etc.)
      /// </summary>
      /// <param name="wavelength">Wavelength value.</param>
      /// <param name="intensity">Intensity value.</param>
      /// <param name="temperature">Temperature value.</param>
      /// <param name="humidity">Humidity value.</param>
      /// <param name="edited">When was ManufacturingStep last Edited.</param>
      /// <param name="process">Process FK</param>
      /// <param name="order">Order FK</param>
      public static ManufacturingStep Create(DateTime edited, global::DOS_DAL.Models.Process process, global::DOS_DAL.Models.Order order, decimal wavelength = 0m, decimal intensity = 0m, decimal temperature = 0m, decimal humidity = 0m)
      {
         return new ManufacturingStep(edited, process, order, wavelength, intensity, temperature, humidity);
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
      /// Required, Default value = 0
      /// Wavelength value.
      /// </summary>
      [Required]
      [System.ComponentModel.Description("Wavelength value.")]
      public decimal Wavelength { get; set; }

      /// <summary>
      /// Required, Default value = 0
      /// Intensity value.
      /// </summary>
      [Required]
      [System.ComponentModel.Description("Intensity value.")]
      public decimal Intensity { get; set; }

      /// <summary>
      /// Required, Default value = 0
      /// Temperature value.
      /// </summary>
      [Required]
      [System.ComponentModel.Description("Temperature value.")]
      public decimal Temperature { get; set; }

      /// <summary>
      /// Required, Default value = 0
      /// Humidity value.
      /// </summary>
      [Required]
      [System.ComponentModel.Description("Humidity value.")]
      public decimal Humidity { get; set; }

      /// <summary>
      /// Required
      /// When was ManufacturingStep last Edited.
      /// </summary>
      [Required]
      [System.ComponentModel.Description("When was ManufacturingStep last Edited.")]
      public DateTime Edited { get; set; }

      /*************************************************************************
       * Navigation properties
       *************************************************************************/

      /// <summary>
      /// User FK
      /// </summary>
      [Description("User FK")]
      public virtual global::DOS_DAL.Models.User EditedBy { get; set; }

      /// <summary>
      /// Required&lt;br/&gt;
      /// Process FK
      /// </summary>
      [Description("Process FK")]
      public virtual global::DOS_DAL.Models.Process Process { get; set; }

      /// <summary>
      /// Required&lt;br/&gt;
      /// Order FK
      /// </summary>
      [Description("Order FK")]
      public virtual global::DOS_DAL.Models.Order Order { get; set; }

   }
}

