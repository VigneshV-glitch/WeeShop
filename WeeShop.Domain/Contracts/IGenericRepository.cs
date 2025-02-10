using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WeeShop.Domain.CommonFields;

namespace WeeShop.Domain.Contracts
{
    /* An interface is 
       does not contain any implementation; 
       it only declares the methods, properties, 
       or events */


    /*Common and Repeated Functions are Initialized               
    which are all going to do some DB Operations */  
    public interface IGenericRepository<T> where T : BaseModel  /*where T : BaseModel: This is a generic type constraint. 
                                                                 * It restricts the type T to be or derive from BaseModel. In other                                                                             words, any class that implements this interface must use a                                                                                    type T that is either the BaseModel itself or a subclass (or                                                                                  derived class) of BaseModel.*/   
    {
        Task<T> CreateAsync(T Entity);

        Task DeleteAsync(T Entity);

        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync (Expression<Func<T, bool>> condition);

        /*No Access Modifiers: Members of an interface are
        implicitly public and cannot have access modifiers
        (like public, private,etc.). They are accessible to
        any class that implements the interface.*/
    }
}
