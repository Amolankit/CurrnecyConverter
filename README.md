**Currency Converter API  (DRAFT MODE)**

Welcome to the Currency Converter API documentation! This API allows you to seamlessly convert currencies based on real-time exchange rates. It's designed to be simple to integrate into your applications, providing accurate and reliable currency conversion functionality.

### Table of Contents
1. [Introduction](#introduction)
2. [Usage](#usage)
3. [Endpoints](#endpoints)
4. [Parameters](#parameters)
5. [Response](#response)
6. [Error Handling](#error-handling)
7. [Rate Limiting](#rate-limiting)
8. [Authentication](#authentication)
9. [Examples](#examples)
10. [Support](#support)

### Introduction
Our Currency Converter API offers a convenient way to convert currencies within your applications. Whether you're building a finance application, an e-commerce platform, or any other system that deals with multi-currency transactions, this API can simplify your development process.

### Usage
To get started, you'll need an API key which you can obtain by signing up on our website. Once you have the API key, you can start making requests to our endpoints.

### Endpoints
- **GET /convert**: Convert one currency to another based on the latest exchange rates.

### Parameters
- **from**: The currency code you want to convert from.
- **to**: The currency code you want to convert to.
- **amount**: The amount you want to convert (optional, default is 1).

### Response
The response will include the converted amount along with the exchange rate used for conversion.

Example response:
```json
{
  "from": "USD",
  "to": "EUR",
  "amount": 1,
  "converted_amount": 0.84,
  "exchange_rate": 0.84
}
```

### Error Handling
The API will return appropriate error codes and messages in case of invalid requests or server errors. Please refer to the response codes for details.

### Rate Limiting
To ensure fair usage of the API, we have rate limiting in place. Each API key is limited to a certain number of requests per minute. If you exceed the limit, you will receive a 429 Too Many Requests response.

### Authentication
All requests to the API endpoints must include your API key in the headers for authentication.

### Examples
**Example Request:**
```http
GET /convert?from=USD&to=EUR&amount=100 HTTP/1.1
Host: api.example.com
Authorization: Bearer YOUR_API_KEY
```

**Example Response:**
```json
{
  "from": "USD",
  "to": "EUR",
  "amount": 100,
  "converted_amount": 84,
  "exchange_rate": 0.84
}
```
