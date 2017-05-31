using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;
using TeduShop.Service;

namespace TeduShop.Unitest.ServiceTest
{
    [TestClass]
    public class PostCategoryServiceTest
    {
        private Mock<IPostCategoryRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private List<PostCategory> _postCategories;
        private IPostCategorySerice _postCategorySerice;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IPostCategoryRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _postCategorySerice = new PostCategoryService(_mockRepository.Object, _mockUnitOfWork.Object);
            _postCategories = new List<PostCategory>
            {
                new PostCategory {Id = 1, Name = "DM1", Alias = "DM1", Status = true},
                new PostCategory {Id = 2, Name = "DM2", Alias = "DM2", Status = true},
                new PostCategory {Id = 3, Name = "DM3", Alias = "DM3", Status = true}
            };
        }

        [TestMethod]
        public void PostCategory_Service_GetAll()
        {
            //setup method
            _mockRepository.Setup(m => m.GetAll(null)).Returns(_postCategories);

            //Call Action 
            var result = _postCategorySerice.GetAll() as List<PostCategory>;

            //Compere
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void PostCategory_Service_Create()
        {
            var category = new PostCategory
            {
                Id = 1,
                Name = "Test",
                Status = true
            };

            //setup method
            _mockRepository.Setup(m => m.Add(category)).Returns((PostCategory p) =>
            {
                p.Id = 1;
                return p;
            });

            //call action 
            var result = _postCategorySerice.Add(category);

            //compere
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
        }
    }
}