using NHibernate.Linq;
using NHibernate;
using RetailCompany.Entities;
using RetailCompany.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace RetailCompany.Data
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ISession _session;

        public EmployeeRepository(ISession session)
        {
            _session = session;
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                await _session.SaveAsync(employee);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction?.RollbackAsync();
            }
            finally
            {
                transaction?.Dispose();
            }
        }

        public async Task DeleteEmployeeAsync(int employeeId)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                var employee = await _session.GetAsync<Employee>(employeeId);
                await _session.DeleteAsync(employee);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction?.RollbackAsync();
            }
            finally
            {
                transaction?.Dispose();
            }
        }

        public async Task<Employee> GetEmployeeByIdAsync(int employeeId)
        {
            return await _session.GetAsync<Employee>(employeeId);
        }


        public async Task UpdateEmployeeAsync(Employee employee)
        {
            ITransaction transaction = null;
            try
            {
                transaction = _session.BeginTransaction();
                await _session.UpdateAsync(employee);
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction?.RollbackAsync();
            }
            finally
            {
                transaction?.Dispose();
            }
        }
        public int CountAllNonAlocatedEmployees()
        {
            return _session.Query<Employee>()
                    .Where(e => e.Store == null)
                    .Count();
        }

        public IList<string> GetAllNonAllocatedEmployessLastName()
        {
            return _session.Query<Employee>()
                    .Where(e => e.Store == null)
                    .Select(e => e.LastName)
                    .ToList();
        }

        public IList<Employee> GetAllEmployees()
        {
            return _session.Query<Employee>().ToList();
        }

        public IList<Employee> GetAllEmployeesWithStore()
        {
            return _session.Query<Employee>()
                .Fetch(x => x.Store)
                //.Left.JoinQueryOver(e => e.Store)
                .ToList();
        }
    }
}
