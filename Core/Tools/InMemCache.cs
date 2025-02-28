namespace NbaApp.Core.Tools;

public class InMemCache<TKey, TValue> {
    
    private class ListNode {
        public TKey key { get; set; }
        public TValue value { get; set; }
        public ListNode next { get; set; }
        public ListNode last { get; set; }

        public ListNode(TKey key, TValue value) {
            this.key = key;
            this.value = value;
            next = default;
            last = default;
        }
    }

    public int capacity { get; private set; }
    private Dictionary<TKey, ListNode> lookupTable;
    private ListNode head;
    private ListNode tail;

    public InMemCache(int capacity) {
        this.capacity = capacity;
        lookupTable = new Dictionary<TKey, ListNode>();
        head = new ListNode(default, default);
        tail = new ListNode(default, default); 
    }

    private void add(ListNode node) {
        ListNode prevTail = tail;
        prevTail.next = node;
        node.last = prevTail;
        node.next = tail;
        tail.last = node;
    }

    private void remove(ListNode node) {
        node.last.next = node.next;
        node.next.last = node.last;
    }

    /// <summary>
    /// Returns a boolean stating whether or not the key exists in the LRU cache
    /// </summary>
    /// <param name="key"></param>
    /// <returns>true if the key is present, false otherwise</returns>
    public bool Contains(TKey key) {
        return lookupTable.ContainsKey(key);
    }

    /// <summary>
    /// Gets a value related to a key
    /// </summary>
    /// <param name="key"></param>
    /// <returns>A value of type TValue if the key exists in the LRU cache, otherwise null</returns>
    public TValue Get(TKey key) {
        if(!Contains(key)) {
            return default;
        }

        ListNode node = lookupTable[key];
        remove(node);
        add(node);
        return node.value;
    }

    /// <summary>
    /// Adds or updates an entry in the LRU cache
    /// </summary>
    /// <param name="key">a key of type TKey to be used to mark the entry</param>
    /// <param name="value">the value of type TValue to be stored at the key's location</param>
    public void Put(TKey key, TValue value) {
        if(Contains(key)) {
            ListNode old = lookupTable[key];
            remove(old);
        }
        
        ListNode newNode = new ListNode(key, value);
        lookupTable.Add(key, newNode);
        add(newNode);

        if(lookupTable.Count > capacity) {
            ListNode deleteNode = head.next;
            remove(deleteNode);
            lookupTable.Remove(deleteNode.key);
        }
    }
}