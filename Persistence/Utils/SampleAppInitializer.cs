using System.Collections.Generic;
using DomainModel;
using DomainModel.Catalog;
using DomainModel.Customers;
using DomainModel.Offices;
using DomainModel.Vehicles;
using Persistence.Facade;

namespace Persistence.Utils
{
    public class SampleAppInitializer
    {
        private readonly DomainModelFacade _facade;

        public SampleAppInitializer(DomainModelFacade facade)
        {
            _facade = facade;
        }

        public void Init()
        {
            var office = Office.Create("офис - 1",  "Novosibirsk", "Krasnii prospect", "1", "1", "555-555", "123-456-789");
            
            var diagnosticItem1 = _facade.DiagnosticItems.Add(new DiagnosticItem {Name = "Диагностика двигателя", Description = "Диагностику инжектора. Проверку системы зажигания. Контроль давления топливной системы. Проверку герметичности впускного коллектора. Анализ работы датчиков при помощи осциллографа. Контроль компрессии по цилиндрам. Проверка состояния ремня ГРМ. Эндоскопирование силового агрегата. Контроль давления масла."}).Entity;
            var diagnosticItem2 =_facade.DiagnosticItems.Add(new DiagnosticItem {Name = "Диагностика ходовой", Description = "проверка всех элементов подвески (амортизаторные стойки, рычаги, шаровые опоры, ступичные подшипники, опорные подшипники, опоры стоек, пружины, пыльники-отбойники); проверка тормозной системы (состояние колодок, тормозных дисков, суппортов, шлангов и трубок); проверка состояния техжидкостей; проверка системы рулевого управления и рулевой рейки; проверка выхлопной системы; проверка приводных валов и ШРУС; проверка состояния защитных чехлов; проверка карданных валов; проверка опор ДВС."}).Entity;

            office.DiagnosticItems.Add(diagnosticItem1);
            office.DiagnosticItems.Add(diagnosticItem2);
            
            _facade.Offices.Add(office);

            _facade.Managers.Add(new Manager
            {
                Firstname = "Andrey", Lastname = "Ivanov", Email = "aaa@mail.ru", EmailConfirmed = true, Office = office,
                Year = 1990, PasswordHash = "AQAAAAEAACcQAAAAEFa8Dz3G2fQzEJUKucnWMsINMcW6EGoJEXVZLE/qx60jSSGT3jYfa2jo9FpGBXXHKw=="
            });

            _facade.Customers.Add(new Customer
            {
                Email = "bbb@mail.ru", FirstName = "NeIvanov", LastName = "NeAndrey", Office = office, Vehicles =
                    new List<Vehicle>
                    {
                        new Vehicle
                        {
                            EngineVolume = (float) 2.00, Firm = "Lada", Model = "Sedan", HandSide = HandSide.LHD,
                            Year = 2021
                        }
                    },
                Address = new Address {City = "Novosibirsk", Street = "Krasnii prospect", Home = "1", Flat = "2"}
            });
            _facade.SaveChanges();
        }
        
    }
}