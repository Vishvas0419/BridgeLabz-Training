# Airport Flight Management System

## 1. Project Overview

The Airport Flight Management System is a C# console-based application designed to manage flights at an airport using different Data Structures and Algorithms.

The system integrates multiple data structures, where each structure is used for a specific airport-management operation:

* **Circular Linked List** → Runway allocation
* **Queue** → Passenger boarding
* **Priority Queue** → Priority passenger boarding
* **Stack** → Cancellation trail
* **Doubly Linked List** → Departure board navigation
* **Dictionary / HashMap** → Flight lookup
* **Sorting** → Organizing flights by departure time
* **Binary Search** → Searching flights by flight code
* **NUnit** → Automated testing

The main objective is to demonstrate how different data structures can work together inside one airport management system.

---

# 2. System Design

The central class of the application is `FlightSystem`.

It manages the different data structures used by the airport.

```text
                         FlightSystem
                              |
        ┌─────────────────────┼─────────────────────┐
        |                     |                     |
        ↓                     ↓                     ↓
 Departure Board          Flight Lookup        Runway Scheduler
 Doubly Linked List       Dictionary            Circular Linked List
        |                     |                     |
        ↓                     ↓                     ↓
 Forward/Backward       FlightCode → Flight    Round-Robin Runways
 Navigation
        |
        ↓
 Boarding System
 Queue / Priority Queue
        |
        ↓
 Passenger Boarding

              Cancellation
                    ↓
                  Stack
                    ↓
            Cancellation Trail
```

---

# 3. Main Classes

## Flight

The `Flight` class represents an airport flight.

It contains information such as:

* Flight Code
* Flight Name
* Boarding/Departure Time
* Cancellation status
* Delay status

Example:

```text
Flight
├── Code
├── Name
├── BoardingTime
├── IsCancelled
└── IsDelayed
```

---

## FlightNode

`FlightNode` is used for the Doubly Linked List representing the departure board.

Each node contains:

```text
Flight Data
Next
Previous
```

The structure looks like:

```text
Flight 101 ⇄ Flight 102 ⇄ Flight 103 ⇄ Flight 104
```

This allows navigation in both directions.

---

## RunwayNode

`RunwayNode` represents a runway in the Circular Linked List.

Example with three runways:

```text
Runway 1 → Runway 2 → Runway 3
    ↑                       ↓
    └───────────────────────┘
```

The circular structure allows runway allocation to continue from the first runway after reaching the last runway.

---

# 4. Overall Project Flow

The overall flow of the system is:

```text
Start Airport System
        ↓
Add Runways
        ↓
Create Flights
        ↓
Add Flights to System
        ↓
Add Passengers to Flights
        ↓
Allocate Runways
        ↓
Board Passengers
        ↓
View Departure Board
        ↓
Navigate Forward / Backward
        ↓
Lookup Flight
        ↓
Sort Flights
        ↓
Binary Search Flight
        ↓
Cancel / Delay Flight
        ↓
Maintain Undo Trail
```

---

# 5. Runway Allocation

## Data Structure

**Circular Linked List**

The airport maintains its runways in a circular structure.

For three runways:

```text
R1 → R2 → R3
↑         ↓
└─────────┘
```

Flights are allocated in round-robin order.

Example:

```text
Flight 101 → Runway 1
Flight 102 → Runway 2
Flight 103 → Runway 3
Flight 104 → Runway 1
Flight 105 → Runway 2
```

The `currentRunway` reference keeps track of the runway that should receive the next flight.

### Complexity

| Operation                 | Time |
| ------------------------- | ---: |
| Add runway                | O(R) |
| Allocate runway to flight | O(F) |
| Space                     | O(R) |

Where:

* `R` = number of runways
* `F` = number of flights

---

# 6. Boarding System

## Normal Boarding

Normal passengers are maintained using a **Queue**.

Queue follows:

```text
FIFO
First In → First Out
```

Example:

```text
Passenger A
Passenger B
Passenger C
```

Boarding order:

```text
A → B → C
```

The system maintains separate queues for different flights.

Conceptually:

```text
Flight 101 → Queue
             ↓
             Passenger A
             Passenger B

Flight 102 → Queue
             ↓
             Passenger C
             Passenger D
```

## Priority Boarding

Priority passengers are handled separately using a **Priority Queue**.

Priority passengers are boarded before normal passengers.

Example:

```text
Priority:
Aman
Simran

Normal:
Rahul
Rohit
```

Boarding order:

```text
Aman
Simran
Rahul
Rohit
```

### Complexity

| Operation                |     Time |
| ------------------------ | -------: |
| Enqueue normal passenger |     O(1) |
| Dequeue normal passenger |     O(1) |
| Priority enqueue         | O(log P) |
| Priority dequeue         | O(log P) |
| Space                    |     O(P) |

Where `P` is the number of passengers.

---

# 7. Cancellation and Undo

## Data Structure

**Stack**

The cancellation trail follows:

```text
LIFO
Last In → First Out
```

When a flight is cancelled, its flight code is pushed onto the stack.

Example:

```text
Cancel Flight 101
Cancel Flight 102
Cancel Flight 103
```

Stack:

```text
TOP
103
102
101
BOTTOM
```

The most recent cancellation can be retrieved first using `Pop()`.

The stack provides the undo trail for cancellation operations.

### Complexity

| Operation         | Time |
| ----------------- | ---: |
| Push cancellation | O(1) |
| Pop cancellation  | O(1) |
| Space             | O(C) |

Where `C` is the number of cancellation actions.

---

# 8. Departure Board

## Data Structure

**Doubly Linked List**

The departure board maintains flights in timeline order.

Example:

```text
09:00 ⇄ 10:00 ⇄ 11:00 ⇄ 12:00
```

Each node contains:

```text
Previous ← Flight → Next
```

Therefore the system can navigate:

### Forward

```text
10:00 → 11:00
```

### Backward

```text
10:00 → 09:00
```

Flights are maintained according to their boarding/departure time.

### Complexity

| Operation           | Time |
| ------------------- | ---: |
| Add flight          | O(F) |
| Forward navigation  | O(F) |
| Backward navigation | O(F) |
| Space               | O(F) |

Where `F` is the number of flights.

---

# 9. Flight Lookup

## Data Structure

**Dictionary / HashMap**

The system maintains:

```text
FlightCode → Flight
```

Example:

```text
101 → Air India
102 → IndiGo
103 → Vistara
```

When a flight code is provided, the Dictionary can directly locate the corresponding flight.

Average lookup complexity is:

```text
O(1)
```

### Complexity

| Operation             | Average Time |
| --------------------- | -----------: |
| Add flight to HashMap |         O(1) |
| Flight lookup         |         O(1) |
| Space                 |         O(F) |

Worst-case HashMap lookup can degrade to O(F), depending on collisions.

---

# 10. Sorting

The system can sort flights based on their required ordering.

## Departure Time Sorting

Flights can be arranged chronologically:

```text
101 → 09:00
102 → 10:00
103 → 11:00
104 → 12:00
```

The current sorting implementation uses nested traversal.

### Complexity

```text
Time: O(F²)
Space: O(1)
```

The sorting is performed by swapping the `Flight` objects stored inside nodes rather than rearranging the nodes themselves.

---

# 11. Binary Search

Binary Search is used to search for a flight using its flight code.

Binary Search requires the search data to be sorted by the same key being searched.

Therefore:

```text
Flight List
     ↓
Sort by Flight Code
     ↓
Binary Search
     ↓
Flight Code
     ↓
Flight Details
```

Example:

```text
101
102
103
104
105
```

Searching for:

```text
104
```

allows Binary Search to repeatedly divide the search range.

### Complexity

| Operation               |                                Time |
| ----------------------- | ----------------------------------: |
| Binary Search           |                            O(log F) |
| Temporary list creation |                                O(F) |
| Sorting before search   | O(F²) with current sorting approach |
| Extra space             |                                O(F) |

The actual binary-search portion itself is **O(log F)**.

---

# 12. Edge Cases

The system is designed to handle important airport-management edge cases.

## No Flights

If there are no flights:

```text
No flights available
```

is displayed during runway allocation.

## No Runway

If no runway has been added:

```text
No runway available
```

is displayed.

## Empty Boarding Queue

If a flight has no passengers waiting:

```text
Boarding queue is empty
```

is displayed.

## Priority Passenger

Priority passengers are processed before normal passengers.

## Cancelled Flight

A cancelled flight is marked as cancelled and should not be processed as a normal active flight.

## Delayed Flight

A delayed flight has its departure/boarding time updated and is marked as delayed.

## Invalid Flight Code

If a flight code does not exist:

```text
Invalid Flight Code
```

is displayed.

---

# 13. Testing — NUnit

The project uses **NUnit** for automated testing.

The tests cover:

* Forward navigation
* Backward navigation
* First flight boundary
* Last flight boundary
* Invalid time
* Runway allocation
* Adding flights
* Empty boarding queue
* Flight cancellation
* Integrated workflows

The project requires:

```text
Minimum tests: 10
Integrated workflows: 2
```

The test suite should verify both normal operations and important edge cases.

---

# 16. Complexity Summary

Let:

* `F` = number of flights
* `R` = number of runways
* `P` = number of passengers
* `C` = number of cancellation actions

| Feature           | Data Structure        |                 Time Complexity | Space |
| ----------------- | --------------------- | ------------------------------: | ----: |
| Add Flight        | Doubly Linked List    |                            O(F) |  O(F) |
| Runway allocation | Circular Linked List  |                            O(F) |  O(R) |
| Add Runway        | Circular Linked List  |                            O(R) |  O(R) |
| Normal boarding   | Queue                 |                            O(P) |  O(P) |
| Priority boarding | Priority Queue        |                      O(P log P) |  O(P) |
| Cancellation      | Stack                 | O(F) to find flight + O(1) push |  O(C) |
| Undo cancellation | Stack                 |                            O(F) |  O(C) |
| Flight lookup     | Dictionary            |                    O(1) average |  O(F) |
| Sort flights      | Linked List traversal |                           O(F²) |  O(1) |
| Binary Search     | List                  |          O(log F) after sorting |  O(F) |

---

# 17. Design Principles

The system uses different data structures because each structure matches a particular real-world airport operation.

```text
Runway allocation
        ↓
Circular Linked List
        ↓
Repeated rotation

Boarding
        ↓
Queue
        ↓
FIFO

Priority boarding
        ↓
Priority Queue
        ↓
Priority first

Cancellation
        ↓
Stack
        ↓
LIFO / Undo trail

Departure board
        ↓
Doubly Linked List
        ↓
Forward + Backward navigation

Flight lookup
        ↓
Dictionary
        ↓
Fast key-based lookup

Flight search
        ↓
Binary Search
        ↓
Divide and conquer
```

This separation makes the system easier to understand and demonstrates practical usage of multiple DSA concepts in one application.

---

# 18. Project Structure

A suggested project structure is:

```text
DSAReview/
│
├── Flight.cs
├── FlightNode.cs
├── RunwayNode.cs
├── Passenger.cs
├── FlightSystem.cs
├── Program.cs
│
└── Tests/
    └── FlightSystemTests.cs
```

---

# 19. How to Run

1. Open the project in Visual Studio or another C# IDE.
2. Build the solution.
3. Run the console application using `Program.cs`.
4. For automated tests, open the NUnit Test Explorer.
5. Run all NUnit tests.
6. Verify that all required tests pass.

---

# 20. Conclusion

The Airport Flight Management System demonstrates the practical integration of multiple data structures into a single C# application.

Each structure solves a specific problem:

```text
Circular Linked List → Runway scheduling
Queue               → Passenger boarding
Priority Queue      → Priority boarding
Stack               → Cancellation trail
Doubly Linked List  → Departure navigation
Dictionary          → Flight lookup
Sorting             → Flight ordering
Binary Search       → Flight-code search
NUnit               → Automated testing
```

The project therefore combines fundamental DSA concepts with an airport-management scenario to demonstrate both individual data-structure operations and their integration into a complete system.
