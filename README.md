# 🧪 SauceDemo Automation Framework

## 📌 Overview

This project is a **test automation framework** built to validate the **end-to-end checkout functionality** of the SauceDemo e-commerce application.

It follows **BDD (Behavior Driven Development)** principles using Reqnroll and is designed with **scalability, maintainability, and readability** in mind.

---

## 🚀 Tech Stack

* C# (.NET 6)
* Selenium WebDriver
* Reqnroll (BDD)
* NUnit
* GitHub Actions (CI)

---

## 🧱 Framework Design

This framework is built using industry best practices:

* ✅ Page Object Model (POM)
* ✅ Dependency Injection
* ✅ Fluent Waits & Explicit Waits
* ✅ Clean separation of concerns
* ✅ Reusable components

---

## 📂 Project Structure

```
SauceDemoAutomationFramework/
│
├── SauceDemoAutomation/
│   ├── Drivers/            # WebDriver factory / setup
│   ├── Pages/              # Page Object classes
│   ├── StepDefinitions/    # Step definitions for BDD
│   ├── Features/           # Gherkin feature files
│   ├── Hooks/              # Setup & teardown (Before/After Scenario)
│   ├── TestData/           # JSON test data files
│   ├── Utilities/          # Helpers (Models,Config reader)
│   ├── DI/                 # Dependency Injection setup (Startup.cs)
├── .github/workflows/      # GitHub Actions CI
├── SauceDemoAutomation.sln
```

---

## 🧪 Test Coverage

The automation suite validates the **complete checkout flow**, including:

### ✅ Happy Paths

* Login with valid credentials
* Add single product to cart
* Add multiple products to cart
* Complete checkout with valid details

### ✅ Validations

* Cart badge count updates correctly
* Correct products are added to cart
* Total price calculation is accurate
* Order confirmation message is displayed

---

## 🧾 Sample Scenario (BDD)

```gherkin
Feature: Checkout Flow

Scenario: Successful checkout with multiple products
  Given I am logged in as a valid user
  When I add the following products to the cart
    | Product Name           |
    | Sauce Labs Backpack    |
    | Sauce Labs Bike Light  |
  And I proceed to checkout
  And I enter valid checkout details
  Then I should see correct cart items and total price
  And I confirm the order
  Then the order should be placed successfully
```

---

## ⚙️ Configuration

Test data and environment settings are stored in JSON files:

* `config.json` → URL, browser, credentials
* `checkoutData.json` → user checkout details

---

## ▶️ How to Run Tests

### 🔹 Locally

```bash
dotnet restore
dotnet build
dotnet test
```

---

### 🔹 Via GitHub Actions (CI)

* Tests run automatically on:

  * Push to `main`
  * Pull requests
* Can also be triggered manually

---

## ⏳ Wait Strategy

The framework uses:

* Explicit waits
* Fluent waits

👉 This ensures stability by handling dynamic elements effectively.

---

## 📌 Assumptions

* Standard user credentials are used:

  * Username: `standard_user`
  * Password: `secret_sauce`
* Chrome browser is used for execution
* Tests run in headless mode in CI

---

## 📈 Future Improvements

* Add cross-browser execution
* Integrate reporting (Extent Reports / Allure)
* Add negative scenarios (invalid checkout details)
* Parameterize environment configs

---

## 👨‍💻 Author

Nipun Vidushan

---

## ✅ Conclusion

This framework demonstrates a **robust, scalable, and maintainable automation solution** aligned with real-world QA engineering practices.
