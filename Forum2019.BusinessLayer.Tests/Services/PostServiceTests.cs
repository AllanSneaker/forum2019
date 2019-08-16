using AutoMapper;
using ForumEpam2019.BusinessLayer.Configurations;
using ForumEpam2019.BusinessLayer.DTO;
using ForumEpam2019.BusinessLayer.Interfaces;
using ForumEpam2019.BusinessLayer.Services;
using ForumEpam2019.Entities.Interfaces;
using ForumEpam2019_Entities.Interfaces;
using ForumEpam2019_Entities.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Forum2019.BusinessLayer.Tests.Services
{
    [TestFixture]
    public class PostServiceTests
    {
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IRepository<Author>> _authorRepository;
        private Mock<IRepository<Comment>> _commentRepository;
        private Mock<IRepository<Post>> _postRepository;
        private Mock<IRepository<HashTag>> _hashTagRepository;
        private IPostService _postService;

        [SetUp]
        public void Initialize()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _authorRepository = new Mock<IRepository<Author>>();
            _commentRepository = new Mock<IRepository<Comment>>();
            _postRepository = new Mock<IRepository<Post>>();
            _hashTagRepository = new Mock<IRepository<HashTag>>();

            _unitOfWork.Setup(x => x.Authors).Returns(_authorRepository.Object);
            _unitOfWork.Setup(x => x.Comments).Returns(_commentRepository.Object);
            _unitOfWork.Setup(x => x.Posts).Returns(_postRepository.Object);
            _unitOfWork.Setup(x => x.HashTags).Returns(_hashTagRepository.Object);

            _postService = new PostService(_unitOfWork.Object);
        }


        static PostServiceTests()
        {
            try
            {
                Mapper.Initialize(cfg => AutoMapperConfig.Initialize());
            }
            catch { }
        }


        #region AddPost

        [Test]
        public void AddPost_should_throw_ArgumentNullException_when_input_entity_is_null()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _postService.AddPost(null));
        }

        [Test]
        public void AddPost_repository_should_be_created_once()
        {
            //Arrange
            var post = new PostDto() { Author = It.IsAny<string>() };
            _authorRepository.Setup(x => x.Find(It.IsAny<Func<Author, bool>>())).Returns(new List<Author>() { new Author() { UserName = It.IsAny<string>() } });

            //Act
            _postService.AddPost(post);

            //Assert
            _postRepository.Verify(x => x.Create(It.IsAny<Post>()), Times.Once);
        }

        [Test]
        public void AddPost_should_create_post_if_author_exists_in_the_database()
        {
            //Arrange
            var post = new PostDto() { Author = It.IsAny<string>() };
            _authorRepository.Setup(x => x.Find(It.IsAny<Func<Author, bool>>())).Returns(new List<Author>() { new Author() { UserName = It.IsAny<string>() } });

            //Act
            _postService.AddPost(post);

            //Assert
            _postRepository.Verify(x => x.Create(It.IsAny<Post>()));
        }
        #endregion


        #region EditPost

        [Test]
        public void EditPost_should_throw_ArgumentNullException_if_input_entity_is_null()
        {
            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => _postService.EditPost(null));
        }

        [Test]
        public void EditPost_should_edit_post()
        {
            //Arrange
            var post = new PostDto() { Title = It.IsAny<string>() };
            _postRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new Post() { Title = It.IsAny<string>() });

            //Act
            _postService.EditPost(post);

            //Assert
            _postRepository.Verify(x => x.Update(It.IsAny<Post>()));
        }

        #endregion


        #region DeletePost


        [Test]
        public void DeletePost_should_delete_post()
        {
            //Arrange
            _postRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new Post() { Title = It.IsAny<string>() });

            //Act
            _postService.DeletePost(It.IsAny<int>());

            //Assert
            _postRepository.Verify(x => x.Delete(It.IsAny<int>()));
        }
        #endregion


        #region GetPost

        [Test]
        public void GetPost_should_get_post_by_id()
        {
            //Arrange
            _postRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new Post() { Title = It.IsAny<string>() });

            //Act
            var post = _postService.GetPost(It.IsAny<int>());

            //Assert
            _postRepository.Verify(x => x.Get(It.IsAny<int>()));
        }

        #endregion

    }
}
