using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Data.Entity;
using Council_Tracker.Models;
using Council_Tracker.DAL;
using System.Collections.Generic;
using System.Linq;

namespace Council_Tracker.Tests.DAL
{
    [TestClass]
    public class CTrackerRepositoryTests
    {
        private Mock<DbSet<Ordinance>> mock_ords { get; set; }
        private Mock<DbSet<Resolution>> mock_resolutions { get; set; }
        private Mock<DbSet<CouncilMember>> mock_members { get; set; }
        private Mock<DbSet<ApplicationUser>> mock_app_users { get; set; }
        private CTrackerRepository repo { get; set; }
        private Mock<CTrackerContext> mock_context { get; set; }
        private List<ApplicationUser> faux_app_users { get; set; } 
        private List<Ordinance> faux_ord_list { get; set; }
        private List<Resolution> faux_res_list { get; set; }
        private List<CouncilMember> faux_member_list { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            mock_members = new Mock<DbSet<CouncilMember>>();
            mock_resolutions = new Mock<DbSet<Resolution>>();
            mock_ords = new Mock<DbSet<Ordinance>>();
            mock_app_users = new Mock<DbSet<ApplicationUser>>();
            repo = new CTrackerRepository();
            mock_context = new Mock<CTrackerContext>();
            faux_app_users = new List<ApplicationUser>();
            faux_ord_list = new List<Ordinance>();
            faux_res_list = new List<Resolution>();
            faux_member_list = new List<CouncilMember>();
        }
          
        public void ConnectToDatastore()
        {
            var query_faux_users = faux_app_users.AsQueryable();
            //var query_moq_users = mock_app_users.AsQueryable();
            var query_ords = faux_ord_list.AsQueryable();
            var query_resolutions = faux_res_list.AsQueryable();
            var query_members = faux_member_list.AsQueryable();

            mock_ords.As<IQueryable<Ordinance>>().Setup(o => o.Provider).Returns(query_ords.Provider);
            mock_ords.As<IQueryable<Ordinance>>().Setup(o => o.Expression).Returns(query_ords.Expression);
            mock_ords.As<IQueryable<Ordinance>>().Setup(o => o.ElementType).Returns(query_ords.ElementType);
            mock_ords.As<IQueryable<Ordinance>>().Setup(o => o.GetEnumerator()).Returns(query_ords.GetEnumerator());
            mock_context.Setup(c => c.Ordinances).Returns(mock_ords.Object);
            mock_ords.Setup(o => o.Add(It.IsAny<Ordinance>())).Callback((Ordinance ord) => faux_ord_list.Add(ord));

            mock_resolutions.As<IQueryable<Resolution>>().Setup(o => o.Provider).Returns(query_resolutions.Provider);
            mock_resolutions.As<IQueryable<Resolution>>().Setup(o => o.Expression).Returns(query_resolutions.Expression);
            mock_resolutions.As<IQueryable<Resolution>>().Setup(o => o.ElementType).Returns(query_resolutions.ElementType);
            mock_resolutions.As<IQueryable<Resolution>>().Setup(o => o.GetEnumerator()).Returns(query_resolutions.GetEnumerator());
            mock_context.Setup(c => c.Resolutions).Returns(mock_resolutions.Object);

            mock_members.As<IQueryable<CouncilMember>>().Setup(o => o.Provider).Returns(query_members.Provider);
            mock_members.As<IQueryable<CouncilMember>>().Setup(o => o.Expression).Returns(query_members.Expression);
            mock_members.As<IQueryable<CouncilMember>>().Setup(o => o.ElementType).Returns(query_members.ElementType);
            mock_members.As<IQueryable<CouncilMember>>().Setup(o => o.GetEnumerator()).Returns(query_members.GetEnumerator());
            mock_context.Setup(c => c.Council_Members).Returns(mock_members.Object);
        }

        [TestMethod]
        public void CanCreateRepoInstance()
        {
            CTrackerRepository repo = new CTrackerRepository();
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void CanGetOrds()
        {
            //Arrange 
            ConnectToDatastore();
            Ordinance ord = new Ordinance { Body = "blah", OrdNumber = 1 };
            //Act
            repo.ManuallyAddOrd(ord);
            int expected = 1;
            var actual = repo.GetOrds();
            //Assert
            Assert.AreEqual(expected, actual.Count());
        }
        [TestMethod]
        public void CanGetResolutions()
        {
            //Arrange
            ConnectToDatastore();
            Resolution res = new Resolution { Body = "blahblah", ResNumber = 5 };
            //Act
            repo.ManuallyAddRes(res);
            int expected = 1;
            var actual = repo.GetResolutions();
            //Assert
            Assert.AreEqual(expected, actual.Count());
        }
        [TestMethod]
        public void CanGetMembers()
        {
            //Arrange
            ConnectToDatastore();
            CouncilMember mem = new CouncilMember { Name = "tobey", ID = 100, Office = "vice mayor" };
            //Act
            repo.ManuallyAddMember(mem);
            int expected = 1;
            var actual = repo.GetMembers();
            //Assert
            Assert.AreEqual(expected, actual.Count());
        }
    }
}
