using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //Importamos este modelo

namespace WebApp_Validaciones.Models
{
    public class Persona
    {
        //Los atributos de anotaciones de datos se declaran previo al nombre de la propiedad encerrado entre corchetes.
        [Required(ErrorMessage = "El Nombre es obligatorio")] //Si queremos que una propiedad se cargue por teclado en forma obligatorio definimos "Required"
        [MinLength(10, ErrorMessage = "El Nombre de usuario debe tener al menos 10 caracteres")] //ErrorMenssage con el texto a mostrar en la vista si el operador no carga nada en el control
        public String Nombre { get; set; }

        [Range(1, 18, ErrorMessage = "La edad debe estar entre 1 y 18")]
        public int Edad { get; set; }

        [EmailAddress(ErrorMessage = "Debe ingresar un mail válido")]
        public String Email { get; set; }

        [RegularExpression("[MmFf]", ErrorMessage = "Solo puede ingresar una M o F")]
        public String Genero { get; set; }
    }
}

/*
 Las anotaciones más comunes que podemos utilizar son:

Required: Indicamos que la propiedad no puede estar vacía.
Range: Definimos el valor mínimo y máximo de la propiedad numérica.
EmailAddress: Valida que el email tenga un formato correcto.
MinLength: Definimos el mínimo número de caracteres que debe cargarse.
ManLength: Definimos el máximo número de caracteres que debe cargarse.
RegularExpression: Definimos una expresión regular que debe cumplir la propiedad.
CustomValidation: Especificamos un método de validación que codificamos nosotros.

 */
