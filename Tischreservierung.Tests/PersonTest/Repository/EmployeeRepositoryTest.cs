using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tischreservierung.Data;
using Tischreservierung.Data.Person;
using Tischreservierung.Models.Person;
using Xunit.Sdk;

namespace Tischreservierung.Tests.PersonTest.Repository
{
    public class EmployeeRepositoryTest
    {
        [Fact]
        public void Add_Employee()
        {
            var testObject = new Employee();

            var context = new Mock<OnlineReservationContext>();
            context.Setup(x => x.Employees.Add(testObject));

            // Act
            var repository = new EmployeeRepository(context.Object);
            repository.SetEmployee(testObject);

            //Assert
            context.Verify(x => x.Set<Employee>());
        }
    }
}
