using AutoMapper;
using AutoMapperLibary.UI.DTOS;
using AutoMapperLibary.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoMapperLibary.UI.Controllers
{
    public class ProductController : Controller
    {
        private readonly AutoMapperDatabaseContext _autoMapperDatabaseContext;
        private readonly IMapper _mapper;
        public ProductController(AutoMapperDatabaseContext autoMapperDatabaseContext, IMapper mapper)
        {
            _autoMapperDatabaseContext = autoMapperDatabaseContext;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var products = _mapper.Map<List<ProductDto>>(_autoMapperDatabaseContext.Products.Include(i => i.Category).ToList());

            return View(products);
        }
    }
}
