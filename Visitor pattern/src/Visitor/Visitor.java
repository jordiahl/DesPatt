package Visitor;

import concreteelements.ConcreteElementA;
import concreteelements.ConcreteElementB;

/**
 * Created by jordi on 3/23/2017.
 */
public interface Visitor {
    void VisitConcreteElementA(ConcreteElementA concreteElemenA);
    void VisitConcreteElementB(ConcreteElementB concreteElementB);
}
