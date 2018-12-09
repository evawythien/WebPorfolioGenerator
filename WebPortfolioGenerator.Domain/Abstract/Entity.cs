using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPortfolioGenerator.Domain.Abstract
{
    /// <summary>
    /// Clase que representa una entidad del dominio.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Entity<T> where T : Entity<T>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        //NOTA: La palabra clave virtual se usa para modificar una declaración de método, propiedad, indizador o evento y permitir 
        //que se invalide en una clase derivada.Por ejemplo, cualquier clase que herede este método puede reemplazarlo:
    }
}
