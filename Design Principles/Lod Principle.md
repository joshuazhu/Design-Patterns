#Law of Demeter Principle

##Definition
> * Each unit should have only limited knowledge about other units: only units "closely" related to the current unit.
> * Each unit should only talk to its friends; don't talk to strangers.
> * Only talk to your immediate friends.

##Advantages
The advantage of following the Law of Demeter is that the resulting software tends to be more maintainable and adaptable. Since objects are less dependent on the internal structure of other objects, object containers can be changed without reworking their callers.

##Disadvantage
Although the LoD increases the adaptiveness of a software system, it may also result in having to write many wrapper methods to propagate calls to components; in some cases, this can add noticeable time and space overhead.