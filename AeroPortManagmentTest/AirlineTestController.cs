using AeroPortManagment.Controllers;
using AeroPortManagment.DTOs;
using AeroPortManagment.HelperDto;
using AeroPortManagment.Interface;
using AeroPortManagment.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AeroPortManagmentTest
{
    public class AirlineTestController
    {
        private readonly Mock<IAirlineRepository> _mockRepo;
        private readonly Mock<IMapper> _mockMapper;
        private readonly AirlineController _controller;

        public AirlineTestController()
        {
            _mockRepo = new Mock<IAirlineRepository>();
            _mockMapper = new Mock<IMapper>();
            _controller = new AirlineController(_mockRepo.Object, _mockMapper.Object);
        }
    

        [Fact]
        public void GetAllAirline_ReturnsOkResult_WithListOfAirlineDTOs()
        {
            // Arrange
            var airlines = new List<Airline> { new Airline { AirlineId = Guid.NewGuid(), Name = "Test Airline" } };
            var airlineDTOs = new List<AirlineDTO> { new AirlineDTO { AirlineId = Guid.NewGuid(), Name = "Test Airline DTO" } };

            _mockRepo.Setup(repo => repo.GetAll()).Returns(airlines);
            _mockMapper.Setup(m => m.Map<List<AirlineDTO>>(It.IsAny<List<Airline>>())).Returns(airlineDTOs);

            // Act
            var result = _controller.GetAllAirline();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<AirlineDTO>>(okResult.Value);
            Assert.Single(returnValue);
        }

        [Fact]
        public void GetAirlineId_ExistingId_ReturnsOkResult_WithAirlineDTO()
        {
            // Arrange
            var airline = new Airline { AirlineId = Guid.NewGuid(), Name = "Test Airline" };
            var airlineDTO = new AirlineDTO { AirlineId = airline.AirlineId, Name = "Test Airline DTO" };

            _mockRepo.Setup(repo => repo.GetAirlineById(It.IsAny<Guid>())).Returns(airline);
            _mockMapper.Setup(m => m.Map<AirlineDTO>(airline)).Returns(airlineDTO);

            // Act
            var result = _controller.GetAirlineId(airline.AirlineId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<AirlineDTO>(okResult.Value);
            Assert.Equal(airlineDTO.AirlineId, returnValue.AirlineId);
        }

        [Fact]
        public void GetAirlineId_NonExistingId_ReturnsNotFoundResult()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetAirlineById(It.IsAny<Guid>())).Returns((Airline)null);

            // Act
            var result = _controller.GetAirlineId(Guid.NewGuid());

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void CreateAirline_ValidObject_ReturnsCreatedAtAction()
        {
            // Arrange
            var createDTO = new CreateAirlineDTO { Name = "New Airline" };
            var airline = new Airline { AirlineId = Guid.NewGuid(), Name = "New Airline" };

            _mockMapper.Setup(m => m.Map<Airline>(createDTO)).Returns(airline);

            // Act
            var result = _controller.CreateAirline(createDTO);

            // Assert
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(nameof(_controller.GetAirlineId), createdAtActionResult.ActionName);
        }

        [Fact]
        public void UpdateAirline_ValidObject_ReturnsNoContent()
        {
            // Arrange
            var id = Guid.NewGuid();
            var updateDTO = new UpdateAirlineDTO { Name = "Updated Airline" };
            var existingAirline = new Airline { AirlineId = id, Name = "Old Airline" };

            _mockRepo.Setup(repo => repo.GetAirlineById(id)).Returns(existingAirline);

            // Act
            var result = _controller.UpdatedAirline(id, updateDTO);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeleteAirline_ExistingId_ReturnsNoContent()
        {
            // Arrange
            var id = Guid.NewGuid();
            var existingAirline = new Airline { AirlineId = id, Name = "Test Airline" };

            _mockRepo.Setup(repo => repo.GetAirlineById(id)).Returns(existingAirline);

            // Act
            var result = _controller.DeleteAirline(id);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public void DeleteAirline_NonExistingId_ReturnsNotFound()
        {
            var nonExistingId = Guid.NewGuid(); // Use a specific ID for clarity
            _mockRepo.Setup(repo => repo.GetAirlineById(nonExistingId)).Returns((Airline)null);

            // Act
            var result = _controller.DeleteAirline(nonExistingId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}