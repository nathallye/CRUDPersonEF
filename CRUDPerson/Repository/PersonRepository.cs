using System.Data.SqlClient;
using System.Data;

using CRUDPerson.Models;
using CRUDPersonEF.Repository.context;

namespace CRUDPerson.Repository
{
    public class PersonRepository
    {
        // Propriedade que terá a instância do DataBaseContext
        private readonly DataBaseContext context;

        public PersonRepository()
        {
            // Criando um instância da classe de contexto do EntityFramework
            context = new DataBaseContext();
        }


        public IList<Person> GetAll()
        {
            return context.Person.ToList();
        }

        public IList<Person> ListOrderedByName()
        {
            var lista =
                context.Person.OrderBy(t => t.Name).ToList<Person>();

            return lista;
        }

        public IList<Person> ListOrderedByNameDescending()
        {
            var lista =
                context.Person.OrderByDescending(t => t.Name).ToList<Person>();

            return lista;
        }

        public Person QueryByAddress(string address)
        {
            // Retorno único
            Person tipo =
                context.Person.Where(t => t.Address == address)
                    .FirstOrDefault<Person>();

            return tipo;
        }

        public IList<Person> QueryPartAddresso(string partAddress)
        {
            // Filtro com Where e Contains
            var lista =
                context.Person.Where(t => t.Address.Contains(partAddress))
                        .ToList<Person>();

            return lista;
        }

        public Person Read(int id)
        {
            return context.Person.Find(id);
        }


        public void Create(Person person)
        {
            context.Person.Add(person);
            context.SaveChanges();
        }

        public void Update(Person person)
        {
            context.Person.Update(person);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            // Criar um tipo produto apenas com o Id
            var person = new Person()
            {
                Id = id
            };

            context.Person.Remove(person);
            context.SaveChanges();
        }
    }
}
