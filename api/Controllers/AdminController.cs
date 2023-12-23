using api.Contracts.Services;
using api.Dtos.LeaveDtos;
using api.Utilities;
using api.Utilities.Enums;
using api.Utilities.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers;

public class AdminController : ControllerBase
{
    private readonly ILeaveCategoryService leaveCategoryService;

    public AdminController(ILeaveCategoryService leaveCategoryService)
    {
        this.leaveCategoryService = leaveCategoryService;
    }

    // LEAVE CATEGORY MANAGEMENT
    [HttpGet("/leave-category/")]
    public IActionResult GetAllLeaveCategory()
    {
        var getLeaveCategories = leaveCategoryService.GetAll();

        var successResponse = ResponseHandler.Ok<IEnumerable<LeaveCategoryDto>>(getLeaveCategories.Message, getLeaveCategories.Result);

        switch (getLeaveCategories.Status)
        {
            case ActionStatus.SUCCESS:
                return Ok(successResponse);

            case ActionStatus.NOT_FOUND:
                return NotFound(successResponse);

            default:
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseHandler.InternalServerError(getLeaveCategories.Message));
        }
    }

    [HttpPost("/leave-category/")]
    public IActionResult CreateLeaveCategory(CreateLeaveCategoryDto createData)
    {
        var createLeaveCategory = leaveCategoryService.Create(createData);

        var successResponse = ResponseHandler.Ok<string>(createLeaveCategory.Message);

        switch (createLeaveCategory.Status)
        {
            case ActionStatus.SUCCESS:
                return Ok(successResponse);

            case ActionStatus.CONFLICT:
                return Conflict(ResponseHandler.Conflict(createLeaveCategory.Message));

            default:
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseHandler.InternalServerError(createLeaveCategory.Message));
        }
    }
}
