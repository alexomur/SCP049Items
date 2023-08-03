# SCP049Items
EXILED SCP:SL Plugin that let's SCP-049 to pick up, use and drop items.

# Config
```
SCP049Items:
  is_enabled: true
  debug: false
```

# Commands
`.pickup` - SCP-049 will pickup the item to his inventory;

`.items` - You'll see the SCP-049's inventory;

`.take [index]` - SCP-049 will take the item in hands by index (You can find out the index via `.items`) from it's inventory. (If the index is not specified, SCP-049 will take everything out of hand);

`.drop [index]` - SCP-049 will drom the item from his inventory by index (If the index is not specified, SCP-049 will drop the item in hand).
