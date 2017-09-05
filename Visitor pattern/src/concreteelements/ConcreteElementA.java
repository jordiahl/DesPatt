package concreteelements;

import Visitor.*;

/**
 * Created by jordi on 3/23/2017.
 */
public class ConcreteElementA implements ConcreteElements{
    public void acceptVisitor(Visitor visitor){
        visitor.VisitConcreteElementA(this);
    }
}
