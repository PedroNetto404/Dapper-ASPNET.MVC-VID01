using ListaDeContatos.WEBApp.Models.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeContatos.WEBApp.Controllers;

public class ContatoController : Controller
{
    [HttpGet("{pessoaId:guid}")]
    public async Task<IActionResult> Listar(Guid pessoaId)
    {
        return View(); 
    }

    [HttpGet]
    public async Task<IActionResult> Adicionar()
    {
        return View(); 
    }

    [HttpPost]
    public async Task<IActionResult> Adicionar(Contato contato)
    {
        return RedirectToAction("Listar", routeValues: contato.DonoId); 
    }
    
    [HttpGet("{contatoId:guid}")]
    public async Task<IActionResult> Editar(Guid contatoId)
    {
        return View(); 
    }
    
    [HttpPost]
    public async Task<IActionResult> Editar(Contato contato)
    {
        return RedirectToAction(); 
    }
    
    [HttpDelete]
    public async Task<IActionResult> ConfirmarExclusao(Guid contatoId)
    {
        return RedirectToAction(); 
    }
    
    [HttpGet]
    public async Task<IActionResult> Excluir(Guid contatoId)
    {
        return View(); 
    }
}