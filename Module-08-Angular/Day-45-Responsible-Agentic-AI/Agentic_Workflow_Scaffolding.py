#!/usr/bin/env python3
import asyncio
import json
from typing import Dict, List, Any

# Trainee note: Python dictionaries are the foundation of LangChain prompts and tool configurations
# Keep tools mapped simply so the model can look up and run the correct function
TOOL_REGISTRY: Dict[str, Any] = {}

def register_tool(name: str):
    """
    Decorator to easily register functions as agent tools.
    Trainee note: using decorators here mimics how Microsoft Foundry and Semantic Kernel register plugins.
    """
    def decorator(func):
        TOOL_REGISTRY[name] = func
        return func
    return decorator

@register_tool("fetch_risk_profile")
async def fetch_risk_profile(invoice_id: int) -> Dict[str, Any]:
    """
    Simulates calling our backend ASP.NET Core endpoint to retrieve risk data.
    """
    # Trainee note: simulating API network call latency
    await asyncio.sleep(0.5)
    
    # Mock response payload matching our C# InvoiceDetailDto schema
    mock_db = {
        101: {"id": 101, "customerName": "Wipro Client Alpha", "totalAmount": 15000.0, "isOverdue": True},
        102: {"id": 102, "customerName": "Beta Corp", "totalAmount": 4500.0, "isOverdue": False}
    }
    
    result = mock_db.get(invoice_id, {"error": "Invoice not found"})
    return result

@register_tool("generate_reminder_template")
async def generate_reminder_template(invoice_data: Dict[str, Any]) -> str:
    """
    Simulates a local prompt template formatting tool for email drafts.
    """
    if "error" in invoice_data:
        return "System Warning: Cannot generate reminder for non-existent invoice."
        
    customer = invoice_data.get("customerName", "Valued Customer")
    amount = invoice_data.get("totalAmount", 0.0)
    
    # Trainee note: strictly enforce safe formatting. Do not use raw string concatenation inside prompt templates!
    prompt_draft = (
        f"Dear {customer},\n\n"
        f"Our records indicate an outstanding balance of ${amount:.2f}. "
        f"Please verify this invoice configuration with your accounts department.\n\n"
        f"Regards,\nFinance Team"
    )
    return prompt_draft

async def run_agentic_workflow(invoice_id: int):
    """
    Coordinates tool execution in sequence based on input arguments.
    """
    print(f"[Agent Loop] Initiating workflow for Invoice ID: {invoice_id}")
    execution_history: List[str] = []

    # 1. Look up tool dynamically from registry
    tool_name = "fetch_risk_profile"
    if tool_name in TOOL_REGISTRY:
        print(f"[Agent Loop] Executing tool: '{tool_name}'...")
        invoice_info = await TOOL_REGISTRY[tool_name](invoice_id)
        execution_history.append(tool_name)
    else:
        print(f"[Agent Error] Tool '{tool_name}' is not registered.")
        return

    # 2. Process data locally using Python standard list/dictionary checks
    print(f"[Agent Loop] Processing tool outputs for Invoice: {json.dumps(invoice_info)}")
    
    if invoice_info.get("isOverdue"):
        print("[Agent Loop] Escalation conditions met. Running prompt generator...")
        
        # Invoke secondary template engine tool
        template_tool = "generate_reminder_template"
        if template_tool in TOOL_REGISTRY:
            draft = await TOOL_REGISTRY[template_tool](invoice_info)
            execution_history.append(template_tool)
            
            print("\n--- Outbox Draft Generated ---")
            print(draft)
            print("------------------------------\n")
        else:
            print(f"[Agent Error] Tool '{template_tool}' is not registered.")
    else:
        print("[Agent Loop] Invoice is not overdue. No action needed.")

    # Trainee note: logging history helps our auditing processes to ensure responsible AI flow
    print(f"[Agent Loop] Task complete. Executed tools sequence: {execution_history}\n")

# Entrypoint verification block
if __name__ == "__main__":
    # Run two different scenarios: a high-risk overdue invoice, and a normal invoice
    asyncio.run(run_agentic_workflow(101))
    asyncio.run(run_agentic_workflow(102))
