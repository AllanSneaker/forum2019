using AutoMapper;
using FluentAssertions;
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
    public class CommentServiceTests
    {
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<IRepository<Author>> _authorRepository;
        private Mock<IRepository<Comment>> _commentRepository;
        private Mock<IRepository<Post>> _postRepository;
        private ICommentService _commentService;

        [SetUp]
        public void Initialize()
        {
            _unitOfWork = new Mock<IUnitOfWork>();
            _authorRepository = new Mock<IRepository<Author>>();
            _commentRepository = new Mock<IRepository<Comment>>();
            _postRepository = new Mock<IRepository<Post>>();

            _unitOfWork.Setup(x => x.Authors).Returns(_authorRepository.Object);
            _unitOfWork.Setup(x => x.Comments).Returns(_commentRepository.Object);
            _unitOfWork.Setup(x => x.Posts).Returns(_postRepository.Object);

            _commentService = new CommentService(_unitOfWork.Object);
        }


        static CommentServiceTests()
        {
            try
            {
                Mapper.Initialize(cfg => AutoMapperConfig.Initialize());
            }
            catch { }
        }

        #region GetAll

        [Test]
        public void GetAll_should_return_list_of_comments()
        {
            //Arrange
            _postRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new Post());
            _commentRepository.Setup(x => x.Find(It.IsAny<Func<Comment, bool>>())).Returns(new List<Comment>());

            //Act
            var comments = _commentService.GetAllComments(It.IsAny<int>());

            //Assert
            comments.Should().NotBeNull();
        }

        #endregion


        #region Reply
        [Test]
        public void Reply_should_throw_ArgumentNullException_if_input_comment_is_null()
        {
            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => _commentService.Reply(It.IsAny<int>(), null));
        }

        [Test]
        public void Reply_should_throw_ArgumentNullException_if_parent_comment_is_null()
        {
            //Arrange
            _commentRepository.Setup(x => x.Get(It.IsAny<int>())).Returns<Comment>(null);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => _commentService.Reply(It.IsAny<int>(), It.IsAny<CommentDto>()));
        }
        #endregion


        #region AddComment

        [Test]
        public void AddComment_should_throw_ArgumentNullException_if_input_comment_is_null()
        {
            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => _commentService.AddComment(It.IsAny<int>(), null));
        }

        [Test]
        public void AddComment_should_throw_ArgumentNullException_if_post_does_not_exist()
        {
            //Arrange
            _postRepository.Setup(x => x.Get(It.IsAny<int>())).Returns<Post>(null);

            //Act & Assert
            Assert.Throws<ArgumentNullException>(() => _commentService.AddComment(It.IsAny<int>(), It.IsAny<CommentDto>()));
        }

        [Test]
        public void AddComment_should_add_if_author_exists_in_the_database()
        {
            //Arrange
            var comment = new CommentDto() { Author = It.IsAny<string>() };
            _postRepository.Setup(x => x.Get(It.IsAny<int>())).Returns(new Post());
            _authorRepository.Setup(x => x.Find(It.IsAny<Func<Author, bool>>())).Returns(new List<Author>() { new Author() { UserName = It.IsAny<string>() } });

            //Act
            _commentService.AddComment(It.IsAny<int>(), comment);

            //Assert
            _commentRepository.Verify(x => x.Create(It.IsAny<Comment>()));
        }

        #endregion


    }
}
