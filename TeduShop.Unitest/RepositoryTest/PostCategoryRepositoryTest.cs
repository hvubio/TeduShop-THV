using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeduShop.Data.Infrastructure;
using TeduShop.Data.Repositories;
using TeduShop.Model.Models;

namespace TeduShop.Unitest.RepositoryTest
{
    [TestClass]
    public class PostCategoryRepositoryTest
    {
        private IDbFactory _dbFactory;
        private IPostCategoryRepository _objRepository;
        private IUnitOfWork _unitOfWork;

        [TestInitialize]
        public void Initialize()
        {
            _dbFactory =new DbFactory();
            _objRepository = new PostCategoryRepository(_dbFactory);
            _unitOfWork = new UnitOfWord(_dbFactory);
            
        }

        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            PostCategory postCategory = new PostCategory();
            postCategory.Name = "Test case";
            postCategory.Alias = "test-case";
            postCategory.Status = true;

            var result = _objRepository.Add(postCategory);
            _unitOfWork.Commit();

            Assert.AreEqual(3,result.Id);
            Assert.IsNotNull(result.Id);
        }

        [TestMethod]
        public void PostCategory_Repository_GetAll()
        {
            var list = _objRepository.GetAll().ToList();

            Assert.AreEqual(3,list.Count);
        }
    }
}
