using DAL.Interfaces;
using Entities.Abstracciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        public IEmpleadoDAL EmpleadoDAL { get; set; }

        private QuizContext _quizContext;

        public UnidadDeTrabajo(QuizContext quizContext,
                        IEmpleadoDAL empleadoDAL)
        {
            this._quizContext = quizContext;
            this.EmpleadoDAL = empleadoDAL;

        }


        public bool Complete()
        {
            try
            {
                _quizContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Dispose()
        {
            this._quizContext.Dispose();
        }
    }
}
