using System;
using Microsoft.AspNetCore.Mvc;
using Lab2_1.Models;

namespace Lab2_1.Controllers;

public class CalcServiceController : Controller 
{
    private readonly float leftNumber;
    private readonly float rightNumber;
    private readonly string summarize;
    private readonly string subtraction;
    private readonly string multiply;
    private readonly string divide;
    private readonly Random random = new();


    public CalcServiceController() 
    {
        leftNumber = random.Next() % 11;
        rightNumber = random.Next() % 11;
        summarize = $"{leftNumber} + {rightNumber} = {leftNumber + rightNumber}";
        subtraction = $"{leftNumber} - {rightNumber} = {leftNumber - rightNumber}";
        multiply = $"{leftNumber} * {rightNumber} = {leftNumber * rightNumber}";
        divide = $"{leftNumber} /  {rightNumber} = {leftNumber / rightNumber}";
    }

    public IActionResult Index() => View();

    public IActionResult PassUsingModel() 
    {
        CalculatorModel model = new(leftNumber, rightNumber, summarize, subtraction, multiply, divide);
        return View(model);
    }

    public IActionResult PassUsingViewData() 
    {
        ViewData["LeftNumber"] = leftNumber;
        ViewData["RightNumber"] = rightNumber;
        ViewData["Summarize"] = summarize;
        ViewData["Subtraction"] = subtraction;
        ViewData["Multiply"] = multiply;
        ViewData["Divide"] = divide;
        
        return View();
    }

    public IActionResult PassUsingViewBag() 
    {
        ViewBag.LeftNumber = leftNumber;
        ViewBag.RightNumber = rightNumber;
        ViewBag.Summarize = summarize;
        ViewBag.Subtraction = subtraction;
        ViewBag.Multiply = multiply;
        ViewBag.Divide = divide;
        
        return View();
    }

    public IActionResult AccessServiceDirectly() 
    {
        CalculatorModel model = new(leftNumber, rightNumber, summarize, subtraction, multiply, divide);
        return View(model);
    }
}