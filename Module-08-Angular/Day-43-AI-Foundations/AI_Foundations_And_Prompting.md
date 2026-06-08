# Day 43: AI Foundations & Prompting

## AI, Machine Learning, and Generative AI Ecosystem (A .NET Engineer's Perspective)

As a Wipro trainee working with full-stack systems, I need to keep the boundaries between AI, Machine Learning, and Generative AI clear:

*   **Artificial Intelligence (AI):** The broad concept of building systems that can simulate human intelligence to solve problems, make decisions, or recognize patterns.
*   **Machine Learning (ML):** A subset of AI focused on training statistical models on structured data to make predictions or classifications without being explicitly programmed.
*   **Generative AI (GenAI):** A subset of deep learning that uses massive transformer-based token models (like GPT-4) to generate new content (text, code, images) by predicting the next probable token based on contextual training data.

### When to Use ML.NET vs. Large Language Models (LLMs)

*   **Local ML.NET (Traditional Statistical Tasks):** 
    For structured regression or classification—such as predicting whether an invoice will be delayed based on past payment days, or forecasting inventory demand based on seasonal sales—we use **ML.NET** packages. 
    *   *Trainee log:* Running ML.NET locally inside our ASP.NET Core process keeps our latency sub-millisecond, ensures zero dependency on external network calls, and eliminates cloud token billing fees.
*   **GenAI / Semantic Kernel (Deep Learning Token Models):**
    For unstructured, highly contextual text tasks—like drafting customer support responses, summarizing long transcripts, or parsing user requests into structured API parameters—we delegate to external deep learning token models (via Azure OpenAI or Semantic Kernel).

---

## The Art of Prompting Matrix

This matrix guides how I structure prompts to ensure the LLM outputs exactly what our full-stack APIs expect, avoiding generic fluff.

| Strategy | Description | Trainee Sandbox Example |
| :--- | :--- | :--- |
| **Dynamic Role Play** | Instructs the model to adopt a specific persona to shape its tone, structure, and professional standards. | `"Act as a Senior .NET Web API Architect. Review this controller code and suggest security optimizations only."` |
| **Template Demonstration (Few-Shot)** | Shows 1-3 concrete input-output examples to teach the model the exact shape of the desired response. | `"Input: Name: John Doe, Age: 30 -> Output: { 'firstName': 'John', 'age': 30 }`<br>`"Input: Name: Jane Smith, Age: 25 -> Output: { 'firstName': 'Jane', 'age': 25 }"` |
| **Specific Constraints** | Enforces strict boundaries on output formatting, length, or content (e.g., forbidding corporate buzzwords). | `"Generate a system error alert. Limit output to exactly 50 words. Do not use generic terms like 'synergy' or 'robust'."` |

---

## Asynchronous Mini-Architecture

This diagram shows how a background task evaluates inputs locally using ML.NET first, then escalates to GenAI if context-aware generation is needed.

```
+---------------------------------------------------------------------------------+
|                          ASP.NET Core Background Thread                         |
|                               (IHostedService)                                  |
+---------------------------------------------------------------------------------+
                                         |
                                         v
                      Incoming Event (e.g., Unprocessed Invoice)
                                         |
                                         v
                  +----------------------------------------------+
                  |         Local ML.NET Invoice Model           |
                  |  (Predicts delayed status & risk score)      |
                  +----------------------------------------------+
                                         |
                       [Is Risk Score > Threshold?]
                                     /       \
                                    Yes       No
                                    /           \
                                   v             v
       +------------------------------------+   +---------------------------------+
       | Azure OpenAI / Semantic Kernel     |   | Save Directly to DB             |
       | (Generate tailored reminder draft) |   | (Fast path, no LLM call)        |
       +------------------------------------+   +---------------------------------+
                                   \             /
                                    v           v
                            [Write to Database / Outbox]
```

### C# Scaffolding: Background Validation Service

```csharp
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

// Trainee note: using ML.NET here keeps our classification local and saves cloud API billing costs
public class PredictiveValidationService : BackgroundService
{
    private readonly ILogger<PredictiveValidationService> _logger;

    public PredictiveValidationService(ILogger<PredictiveValidationService> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Predictive Validation Background Service started.");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                // 1. Check queue for incoming documents
                _logger.LogInformation("Checking background queue for unprocessed invoices...");

                // 2. Perform local ML.NET classification
                bool isHighRisk = PredictRiskLocally(new Invoice { Amount = 15000 });

                if (isHighRisk)
                {
                    _logger.LogWarning("Local ML.NET flagged invoice as high risk. Escolating to Azure OpenAI for reasoning...");
                    await CallGenAIEngineAsync();
                }
                else
                {
                    _logger.LogInformation("Invoice cleared by local ML.NET model. No LLM processing required.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while executing predictive validation task.");
            }

            // Poll every 10 seconds
            await Task.Delay(10000, stoppingToken);
        }
    }

    private bool PredictRiskLocally(Invoice invoice)
    {
        // Trainee note: simulating ML.NET Engine scoring here
        return invoice.Amount > 10000;
    }

    private async Task CallGenAIEngineAsync()
    {
        // Trainee note: simulate Azure OpenAI or Semantic Kernel prompt dispatch
        await Task.Delay(500); // Simulate network latency to OpenAI
        _logger.LogInformation("Draft generated successfully by Azure OpenAI and stored in cache.");
    }
}

public class Invoice
{
    public decimal Amount { get; set; }
}
```
