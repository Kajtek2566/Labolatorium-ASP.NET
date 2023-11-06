using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Lab_3.Models;
using System.Collections.Generic;

public class ContactController : Controller
{
    private Dictionary<int, Contact> _contacts = new Dictionary<int, Contact>();

    [HttpGet]
    public IActionResult Edit(int id)
    {
        // Pobierz kontakt o podanym id i przekaż go do widoku Edit
        Contact contact = _contacts[id]; // Przykład pobrania kontaktu z kolekcji _contacts
        return View(contact);
    }

    [HttpPost]
    public IActionResult Edit(Contact contact)
    {
        // Zapisz zmieniony kontakt
        // Przekieruj do widoku Index po zapisaniu
        // Przykład implementacji zapisu kontaktu
        if (ModelState.IsValid)
        {
            // Zapisz kontakt do kolekcji lub bazy danych
            _contacts[contact.Id] = contact; // Przykład aktualizacji kontaktu w kolekcji _contacts
            return RedirectToAction("Index");
        }
        // Obsłuż przypadki, gdy ModelState.IsValid jest false
        return View(contact);
    }

    [HttpGet]
    public IActionResult DeleteGet(int id)
    {
        // Pobierz kontakt o podanym id i przekaż go do widoku Delete
        Contact contact = _contacts[id]; // Przykład pobrania kontaktu z kolekcji _contacts
        return View(contact);
    }

    [HttpPost]
    public IActionResult DeletePost(int id)
    {
        // Usuń kontakt o podanym id
        // Przekieruj do widoku Index po usunięciu
        // Przykład implementacji usuwania kontaktu
        if (_contacts.ContainsKey(id))
        {
            _contacts.Remove(id); // Przykład usuwania kontaktu z kolekcji _contacts
            return RedirectToAction("Index");
        }
        return NotFound(); // Kontakt o podanym id nie istnieje
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        // Pobierz kontakt o podanym id i przekaż go do widoku Details
        Contact contact = _contacts[id]; // Przykład pobrania kontaktu z kolekcji _contacts
        return View(contact);
    }

}
