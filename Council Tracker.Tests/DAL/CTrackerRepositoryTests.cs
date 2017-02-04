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
        private CTrackerRepository repo { get; set; }
        private Mock<CTrackerContext> mock_context { get; set; }
        private Mock<DbSet<Ordinance>> mock_ords { get; set; }
        private Mock<DbSet<Resolution>> mock_resolutions { get; set; }
        private Mock<DbSet<CouncilMember>> mock_members { get; set; }
        private Mock<DbSet<ApplicationUser>> mock_app_user { get; set; }
        private List<ApplicationUser> mock_app_users_list { get; set; }
        private List<Ordinance> mock_ord_list { get; set; }
        private List<Resolution> mock_res_list { get; set; }
        private List<CouncilMember> mock_member_list { get; set; }

        [TestInitialize]
        public void Initialize()
        {

            mock_context = new Mock<CTrackerContext>();

            mock_members = new Mock<DbSet<CouncilMember>>();
            mock_member_list = new List<CouncilMember>();
            CouncilMember bogus_council_member = new CouncilMember() { ID = 1, Name = "Roger" };
            mock_member_list.Add(bogus_council_member);

            mock_ords = new Mock<DbSet<Ordinance>>();
            mock_ord_list = new List<Ordinance>();
            Ordinance bogus_ord = new Ordinance() { ID = 1, Body = "Bogus Ordinance", OrdNumber = 1 };
            mock_ord_list.Add(bogus_ord);


            mock_resolutions = new Mock<DbSet<Resolution>>();
            mock_res_list = new List<Resolution>();
            Resolution bogus_res = new Resolution() { ID = 1, Body = "Bogus Resolution", ResNumber = 1 };
            mock_res_list.Add(bogus_res);

            mock_app_user = new Mock<DbSet<ApplicationUser>>();
            mock_app_users_list = new List<ApplicationUser>();
            ApplicationUser bogus_user1 = new ApplicationUser() { Id = "1", UserName = "Tobey" };
            mock_app_users_list.Add(bogus_user1);

            //Thought this would be the way to simulate Tracking, but crashes Initialize()
            //bogus_user1.Ordinances.Add(new Ordinance() { ID = 2, OrdNumber = 2, Body = "Tracked Ord" });
            //bogus_ord.Users.Add(bogus_user1);

            repo = new CTrackerRepository(mock_context.Object);
            ConnectToDatastore();
        }
          
        public void ConnectToDatastore()
        {
            var query_mock_users = mock_app_users_list.AsQueryable();
            var query_ords = mock_ord_list.AsQueryable();
            var query_resolutions = mock_res_list.AsQueryable();
            var query_members = mock_member_list.AsQueryable();

            mock_ords.As<IQueryable<Ordinance>>().Setup(o => o.Provider).Returns(query_ords.Provider);
            mock_ords.As<IQueryable<Ordinance>>().Setup(o => o.Expression).Returns(query_ords.Expression);
            mock_ords.As<IQueryable<Ordinance>>().Setup(o => o.ElementType).Returns(query_ords.ElementType);
            mock_ords.As<IQueryable<Ordinance>>().Setup(o => o.GetEnumerator()).Returns(query_ords.GetEnumerator());
            mock_context.Setup(c => c.Ordinances).Returns(mock_ords.Object);
            mock_ords.Setup(o => o.Add(It.IsAny<Ordinance>())).Callback((Ordinance ord) => mock_ord_list.Add(ord));
            mock_ords.Setup(o => o.Remove(It.IsAny<Ordinance>())).Callback((Ordinance ord) => mock_ord_list.Remove(ord));

            mock_resolutions.As<IQueryable<Resolution>>().Setup(o => o.Provider).Returns(query_resolutions.Provider);
            mock_resolutions.As<IQueryable<Resolution>>().Setup(o => o.Expression).Returns(query_resolutions.Expression);
            mock_resolutions.As<IQueryable<Resolution>>().Setup(o => o.ElementType).Returns(query_resolutions.ElementType);
            mock_resolutions.As<IQueryable<Resolution>>().Setup(o => o.GetEnumerator()).Returns(query_resolutions.GetEnumerator());
            mock_context.Setup(c => c.Resolutions).Returns(mock_resolutions.Object);
            mock_resolutions.Setup(r => r.Add(It.IsAny<Resolution>())).Callback((Resolution res) => mock_res_list.Add(res));
            mock_resolutions.Setup(r => r.Remove(It.IsAny<Resolution>())).Callback((Resolution res) => mock_res_list.Remove(res));

            mock_members.As<IQueryable<CouncilMember>>().Setup(o => o.Provider).Returns(query_members.Provider);
            mock_members.As<IQueryable<CouncilMember>>().Setup(o => o.Expression).Returns(query_members.Expression);
            mock_members.As<IQueryable<CouncilMember>>().Setup(o => o.ElementType).Returns(query_members.ElementType);
            mock_members.As<IQueryable<CouncilMember>>().Setup(o => o.GetEnumerator()).Returns(query_members.GetEnumerator());
            mock_context.Setup(c => c.Council_Members).Returns(mock_members.Object);
            mock_members.Setup(m => m.Add(It.IsAny<CouncilMember>())).Callback((CouncilMember cm) => mock_member_list.Add(cm));
            mock_members.Setup(m => m.Remove(It.IsAny<CouncilMember>())).Callback((CouncilMember cm) => mock_member_list.Remove(cm));

            mock_app_user.As<IQueryable<ApplicationUser>>().Setup(u => u.Provider).Returns(query_mock_users.Provider);
            mock_app_user.As<IQueryable<ApplicationUser>>().Setup(u => u.Expression).Returns(query_mock_users.Expression);
            mock_app_user.As<IQueryable<ApplicationUser>>().Setup(u => u.ElementType).Returns(query_mock_users.ElementType);
            mock_app_user.As<IQueryable<ApplicationUser>>().Setup(u => u.GetEnumerator()).Returns(query_mock_users.GetEnumerator());
            mock_context.Setup(c => c.Users).Returns(mock_app_user.Object);
            mock_app_user.Setup(m => m.Add(It.IsAny<ApplicationUser>())).Callback((ApplicationUser user) => mock_app_users_list.Add(user));
            mock_app_user.Setup(m => m.Remove(It.IsAny<ApplicationUser>())).Callback((ApplicationUser user) => mock_app_users_list.Remove(user));
        }

        [TestMethod]
        public void CanCreateRepoInstance()
        {
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void canReturnOrdList()
        {
            //Arrange 
            //Act
            List<Ordinance> list = repo.GetOrds();
            //Assert
            Assert.IsNotNull(list);
            Assert.AreEqual(1, list.Count());
        }

        [TestMethod]
        public void canReturnResList()
        {
            //Arrange
            //Act
            List<Resolution> list = repo.GetResolutions();
            //Assert
            Assert.IsNotNull(list);
            Assert.AreEqual(1, list.Count());
        }

        [TestMethod]
        public void canReturnMemList()
        {
            //Arrange 
            //Act 
            List<CouncilMember> list = repo.GetMembers();
            //Assert
            Assert.AreEqual(1, list.Count());
            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void CanReturnUser()
        {
            //Arrange 
            string userId = "1";
            //Act 
            ApplicationUser found = repo.ReturnUser(userId);
            //Assert
            Assert.AreEqual(1, repo.Context.Users.Count());
            Assert.AreEqual("Tobey", found.UserName);
        }

        [TestMethod]
        public void CanGetSingleOrd()
        {
            //Arrange
            int ordnumber = 1;
            //Act 
            Ordinance foundOrd = repo.GetSingleOrd(ordnumber);
            //Assert
            Assert.AreEqual(1, repo.Context.Ordinances.Count());
            Assert.AreEqual(1, foundOrd.ID);
        }

        [TestMethod]
        public void CanGetSingleRes()
        {
            //Arrange
            int resnumber = 1;
            //Act
            Resolution foundRes = repo.GetSingleRes(resnumber);
            //Assert
            Assert.AreEqual(1, foundRes.ID);
        }

        [TestMethod]
        public void CanGetSingleMemberByID()
        {
            //Arrange
            int id = 1;
            //Act
            CouncilMember singleMem = repo.GetSingleMember(id);
            //Assert
            Assert.AreEqual(1, singleMem.ID);
        }

        //[TestMethod]
        //public void CanGetTrackedOrdinances()
        //{
        //    //Arrange
          
        //    //Act

        //    //Assert

        //}
    }
}
