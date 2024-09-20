using AeroPortManagment.Controllers;
using AeroPortManagment.DTOs;
using AeroPortManagment.HelperDto;
using AeroPortManagment.Interface;
using AeroPortManagment.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroPortManagmentTest
{
    public class AirportTestController
    {
        private readonly AirportController _controller;
        private readonly Mock<IAirportRepository> _mockRepo;
        private readonly Mock<IMapper> _mockMapper;

        public AirportTestController()
        {
            _mockRepo = new Mock<IAirportRepository>();
            _mockMapper = new Mock<IMapper>();
            _controller = new AirportController(_mockRepo.Object, _mockMapper.Object);
        }

        [Fact]
        public void GetAllAirport_ReturnsOkResult_WithListOfAirports()
        {
            // Arrange
            var airports = new List<Airport> { new Airport { Name = "Airport 1" }, new Airport { Name = "Airport 2" } };
            _mockRepo.Setup(repo => repo.GetAll()).Returns(airports);
            _mockMapper.Setup(mapper => mapper.Map<List<AirportDTO>>(It.IsAny<List<Airport>>()))
                .Returns(new List<AirportDTO> { new AirportDTO { Name = "Airport 1" }, new AirportDTO { Name = "Airport 2" } });

            // Act
            var result = _controller.GetAllAirport();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<List<AirportDTO>>(okResult.Value);
            Assert.Equal(2, returnValue.Count);
        }

        [Fact]
        public void GetAirportId_ReturnsNotFound_WhenAirportDoesNotExist()
        {
            // Arrange
            var airportId = Guid.NewGuid();
            _mockRepo.Setup(repo => repo.GetAirportById(airportId)).Returns<Airport>(null);

            // Act
            var result = _controller.GetAirportId(airportId);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void GetAirportId_ReturnsOkResult_WithValidAirport()
        {
            // Arrange
            var airportId = Guid.NewGuid();
            var airport = new Airport { AirportId = airportId, Name = "Test Airport" };
            _mockRepo.Setup(repo => repo.GetAirportById(airportId)).Returns(airport);
            _mockMapper.Setup(mapper => mapper.Map<AirportDTO>(airport)).Returns(new AirportDTO { Name = "Test Airport" });

            // Act
            var result = _controller.GetAirportId(airportId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<AirportDTO>(okResult.Value);
            Assert.Equal("Test Airport", returnValue.Name);
        }

        [Fact]
        public void CreateAirport_ReturnsBadRequest_WhenModelIsNull()
        {
            // Act
            var result = _controller.CreateAirport(null);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void CreateAirport_ReturnsCreatedResult_WhenAirportIsValid()
        {
            // Arrange
            var createAirportDto = new CreateAirportDTO { Name = "New Airport" };
            var airport = new Airport { Name = "New Airport" };
            _mockMapper.Setup(mapper => mapper.Map<Airport>(createAirportDto)).Returns(airport);

            // Act
            var result = _controller.CreateAirport(createAirportDto);

            // Assert
            var createdResult = Assert.IsType<CreatedResult>(result);
            Assert.Equal("location", createdResult.Location);
        }

        [Fact]
        public void UpdatedAirport_ReturnsBadRequest_WhenModelIsNull()
        {
            // Act
            var result = _controller.UpdatedAirport(Guid.NewGuid(), null);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public void DeleteAirport_ReturnsNoContent_WhenDeleteIsSuccessful()
        {
            // Arrange
            var airportId = Guid.NewGuid();
            _mockRepo.Setup(repo => repo.Delete(airportId));

            // Act
            var result = _controller.DeleteAirport(airportId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
