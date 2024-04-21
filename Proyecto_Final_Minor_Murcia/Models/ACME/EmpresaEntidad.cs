using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Models.ACME
{
    public class EmpresaEntidad
    {
        [Range(0, int.MaxValue, ErrorMessage = "Debe Seleccionar una Empresa." )]
        [Display(Name = "Código" )]

        public int IDEmpresa { get; set; }

        [Required(ErrorMessage = "Debe Seleccionar un Tipo de Empresa.")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe Seleccionar un Tipo Empresa.")]
        [Display(Name = "Tipo Empresa")]
        public int? IDTipoEmpresa { get; set; }

        [Required(ErrorMessage = "El nombre de la empresa es obligatorio.")]
        [Display(Name = "Nombre Empresa")]

        public string Empresa { get; set; } = string.Empty;

        [Required(ErrorMessage = "El Direccion de la empresa es obligatorio.")]
        [Display(Name = "Nombre Direccion")]

        public string Direccion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El RUC de la empresa es obligatorio.")]
        [Display(Name = "RUC")]

        public string RUC { get; set; } = string.Empty ;

        [Required(ErrorMessage = "Debe Ingresar la Fecha De Creacion.")]
        [Display(Name = "Fecha Creacion")]

        public DateTime FechaCreacion { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Debe Ingresar El Presupuesto.")]
        [Display(Name = "Presupuesto")]

        public decimal Presupuesto { get; set; }

        public bool Activo { get; set; } = true;

        //propiedad de navegacion a TipoEmpresa

        public TipoEmpresaEntidad? TipoEmpresaEntidad { get; set; } 




    }
}
