using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace WebPortfolioGenerator.Domain.Abstract
{
    /// <summary>
    /// Interfaz que representa las operaciones mínimas de un repositorio
    /// </summary>
    /// <typeparam name="T">El tipo de la entidad</typeparam>
    public interface IRepository<T> where T : Entity<T>
    {

        //UnitOfWork _UnitOfwork;
    }
}
