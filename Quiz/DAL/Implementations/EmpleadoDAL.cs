using DAL.Interfaces;
using Entities.Abstracciones;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementations
{
    public class EmpleadoDAL : DALGenericoImpl<Empleado>, IEmpleadoDAL
    {
        private QuizContext _context;

        public EmpleadoDAL(QuizContext context) : base(context)
        {
            _context = context;
        }

        public List<Empleado> GetAllEmpleados()
        {
            string query = "sp_GetAllEmployees";

            var result = _context.Empleados.FromSqlRaw(query);

            return result.ToList();
        }

        public bool Add(Empleado entity)
        {
            try
            {
                string sql = "exec [dbo].[sp_AddEmployee] @Nombre, @Salario";

                var param = new SqlParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = "@Nombre",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = entity.Nombre
                    },
                    new SqlParameter()
                    {
                        ParameterName = "@Salario",
                        SqlDbType = System.Data.SqlDbType.Float,
                        Value = entity.Salario
                    }
                 };

                _context
                    .Database
                    .ExecuteSqlRaw(sql, param);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Update(Empleado entity)
        {
            try
            {
                _context.Empleados.Update(entity);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var entity = _context.Empleados.Find(id);
                if (entity != null)
                {
                    _context.Empleados.Remove(entity);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
