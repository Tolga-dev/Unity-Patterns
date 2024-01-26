# Observer Pattern

* it creates a 'one to many' dependency between objects. As one object changes its state the other objects respond automatically.

* The Observer Pattern is a behavioral design pattern where an object, known as the subject, maintains a list of its dependents, called observers, and notifies them of any state changes, usually by calling one of their methods.

# Here's how it works:

## Subject: 
The subject is the main component that holds the state and controls it. It provides methods to register, unregister, and notify observers.

## Observer:
Observers are the dependent components that are interested in the state changes of the subject. They register themselves with the subject to receive notifications.