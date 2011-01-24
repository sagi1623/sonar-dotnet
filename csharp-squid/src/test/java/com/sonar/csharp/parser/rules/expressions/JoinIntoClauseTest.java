/*
 * Copyright (C) 2010 SonarSource SA
 * All rights reserved
 * mailto:contact AT sonarsource DOT com
 */
package com.sonar.csharp.parser.rules.expressions;

import static com.sonar.sslr.test.parser.ParserMatchers.notParse;
import static com.sonar.sslr.test.parser.ParserMatchers.parse;
import static org.junit.Assert.assertThat;

import org.junit.Before;
import org.junit.Test;

import com.sonar.csharp.api.CSharpGrammar;
import com.sonar.csharp.parser.CSharpParser;

public class JoinIntoClauseTest {

  CSharpParser p = new CSharpParser();
  CSharpGrammar g = p.getGrammar();

  @Before
  public void init() {
    p.setRootRule(g.joinIntoClause);
    g.type.mock();
    g.expression.mock();
  }

  @Test
  public void testOk() {
    assertThat(p, parse("join id in expression on expression equals expression into id"));
    assertThat(p, parse("join type id in expression on expression equals expression into id"));
  }

  @Test
  public void testKo() {
    assertThat(p, notParse(""));
  }

}
